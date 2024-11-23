import { SelectionModel } from '@angular/cdk/collections';
import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDatepicker } from '@angular/material/datepicker';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ClientService } from 'src/app/services/client.service';
import { Dataservice } from 'src/app/services/data.service';
import Swal from 'sweetalert2';
import { Product } from '../product/product.component';

interface InvoiceItem {
  description: string;
  hours: number;
  rate: number;
}

interface ProductType {
  productTypeId: number;
  productTypeName: string;
  isExempt: boolean;
}

export interface Receipt {
  receiptId: number;
  clientEmail: string;
  totalTaxes: number;
  totalCost: number;
  created_at: string;
  updated_at: string;
  deleted_at: string;
  isDeleted: boolean;
  receiptItems: ReceiptItem;
}

export interface ReceiptItem {
  receiptItemId: number;
  receiptId: number;
  itemName: string;
  itemPrice: number;
  productTypeName: string;
  isExempted: boolean;
  isImported: boolean;
  quantity: number;
  taxAmount: number;
  priceIncludingTax: number;
  created_at?: string;
  updated_at?: string;
  isDeleted?: boolean;
  deleted_at: string;
}

@Component({
  selector: 'app-add-receipt',
  templateUrl: './add-receipt.component.html',
  styleUrls: ['./add-receipt.component.css'],
})
export class AddReceiptComponent implements OnInit {
  receiptForm: FormGroup;

  productList: Product[] = [];
  producTypetList: ProductType[] = [];

  totalTax: string = '0.00';
  totalCost: string = '0.00';

  companyName = 'Sales Tax (LTD)';
  companyAddress = 'South Africa, JHB';
  companyContact = '+127 67 123-1342';

  issueDate = new Date();

  receiptDetails:
     {
        receiptId: number;
        totalTaxes: number;
        totalCost: number;
        clientName: string;
        clientEmail: string;
        created_at: string;
        updated_at: string;
        isDeleted: boolean;
        deleted_at: string;
        receiptItems: ReceiptItem[];
      }
    | undefined;

  constructor(
    private apiClient: ClientService,
    private apiData: Dataservice,
    public dialog: MatDialog,
    private router: Router,
    private spinner: NgxSpinnerService,
    public datePipe: DatePipe,
    private fb: FormBuilder
  ) {

    this.receiptForm = this.fb.group({
      receiptId: [0],
      totalTaxes: [0],
      totalCost: [0],
      clientName: ['', Validators.required],
      clientEmail: ['', [Validators.required, Validators.email]],
      created_at: [new Date().toISOString()],
      updated_at: [new Date().toISOString()],
      isDeleted: [false],
      deleted_at: [new Date().toISOString()],
      receiptItems: this.fb.array([])
    });
  }

  ngOnInit(): void {

    this.GetAllGoods();
    this.GetAllProductTypes();
    this.calculateTotals();
    this.addItem();

  }

  GetAllGoods(){
    this.apiClient.GetAllGoods().subscribe({
      next: (response: any) => {

          this.productList = response;
      },
      error: (error: any) => {
          console.error("Error fetching data from API:", error);
      },
    });
  }

  GetAllProductTypes(){
    this.apiClient.GetAllProductTypes().subscribe({
      next: (response: any) => {

          this.producTypetList = response;
      },
      error: (error: any) => {
          console.error("Error fetching data from API:", error);
      },
    });
  }

  addItem(): void {
    this.receiptItems.push(
      this.fb.group({
        itemName: [''],
        productTypeName: [''],
        quantity: [1],
        taxAmount: [0],
        priceIncludingTax: [0],
        isExempted: false,
        isImported: false,
        itemPrice: [0]
      })
    );
  }

  get receiptItems(): FormArray {
    return this.receiptForm.get('receiptItems') as FormArray;
  }

  onProductChange(index: number): void {
    const item = this.receiptItems.at(index);

    const selectedProduct = this.productList.find(
      (product) => product.productId === parseInt(item.value.itemName)
    );
    if (selectedProduct) {
      item.patchValue({
        unitPrice: selectedProduct.unitPrice,
      });
  
      this.calculateValues(index, selectedProduct);
    }
  }
  
  onQuantityChange(index: number): void {

    const item = this.receiptItems.at(index);

    const selectedProduct = this.productList.find(
      (product) => product.productId === parseInt(item.value.itemName)
    );

    if (selectedProduct) {
      this.calculateValues(index, selectedProduct);
    }
  }

  calculateValues(index: number, product: any): void {
    const item = this.receiptItems.at(index);
    const quantity = item.value.quantity;

    const basicTaxRate = product.isExempt ? 0 : 0.1;
    const importTaxRate = product.isImport ? 0.05 : 0;
    const taxRate = basicTaxRate + importTaxRate;

    const taxAmount = product.unitPrice * quantity * basicTaxRate + product.unitPrice * quantity * importTaxRate;
    const priceIncludingTax = product.unitPrice * quantity + taxAmount;

    item.patchValue({
      taxAmount: this.roundUpToNearestFiveCents(taxAmount),
      priceIncludingTax: this.roundUpToNearestFiveCents(priceIncludingTax)
    });

    this.calculateTotals();
  }

  calculateTotals(): void {
    let totalTax = 0;
    let totalCost = 0;

    this.receiptItems.controls.forEach((item) => {
      const taxAmount = parseFloat(item.value.taxAmount || 0);
      const priceIncludingTax = parseFloat(item.value.priceIncludingTax || 0);

      totalTax += taxAmount;
      totalCost += priceIncludingTax;
    });

    this.totalTax = totalTax.toFixed(2);
    this.totalCost = totalCost.toFixed(2);

    this.receiptForm.patchValue({
      totalTaxes: totalTax.toFixed(2),
      totalCost: totalCost.toFixed(2),
    });
  }

  roundUpToNearestFiveCents(value: number): number {
    if(value % 0.05 !== 0){
      return value;
    } else {
      return Math.ceil(value / 0.05) * 0.05;
    }
  }

  addReceiptItem(): void {
    const receiptItemGroup = this.fb.group({
      receiptItemId: [0, Validators.required],
      receiptId: [0, Validators.required],
      itemName: ['', Validators.required],
      isImported: [false, Validators.required],
      isExempted: [false, Validators.required],
      productTypeName: ['', Validators.required],
      quantity: [1, [Validators.required, Validators.min(1)]],
      taxAmount: [0, [Validators.required, Validators.min(0)]],
      priceIncludingTax: [0, [Validators.required, Validators.min(0)]],
      created_at: [new Date().toISOString(), Validators.required],
      updated_at: [new Date().toISOString(), Validators.required],
      isDeleted: [false, Validators.required],
      deleted_at: [new Date().toISOString()],
    });

    this.receiptItems.push(receiptItemGroup);
    this.calculateTotals();
  }

  removeReceiptItem(index: number): void {
    this.receiptItems.removeAt(index);
    this.calculateTotals();
  }

  onSubmit(): void {
    // if (this.receiptForm.valid) {
    //   this.saveReceiptForm(this.receiptForm.value)
    // } else {
    //   Swal.fire({
    //     position: "top-end",
    //     icon: "warning",
    //     title: "Form has validations errors!",
    //     showConfirmButton: false,
    //     timer: 1500
    //   });
    // }
    this.saveReceiptForm(this.receiptForm.value)
  }

  saveReceiptForm(body: any){
    this.apiClient.PostInsertReceipt(body)
      .subscribe((response: any) => {

        Swal.fire({
          position: "top-end",
          icon: "success",
          title: "Receipt created successfully!",
          showConfirmButton: false,
          timer: 1500
        });

        this.router.navigate(['/receipts']);
      }, 
      (err) => console.log("error", err)
      );
  }

  getProductNameById(productId: number): string {
    const product = this.productList.find((p) => p.productId === productId);
    return product ? product.productName : '';
  }
}
