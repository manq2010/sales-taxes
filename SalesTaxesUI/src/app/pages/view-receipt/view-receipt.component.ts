import { SelectionModel } from '@angular/cdk/collections';
import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
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

export interface ReceiptItem {
  receiptItemId: number;
  receiptId: number;
  itemName: string;
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
  selector: 'app-view-receipt',
  templateUrl: './view-receipt.component.html',
  styleUrls: ['./view-receipt.component.css'],
})
export class ViewReceiptComponent implements OnInit {

  receiptDetails: {
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
  } | undefined;

  productList: Product[] = [];
  
  constructor(
    private apiClient: ClientService,
    private apiData: Dataservice,
    public dialog: MatDialog,
    private router: Router,
    private spinner: NgxSpinnerService,
    public datePipe: DatePipe
  ) {}

  ngOnInit(): void {
    this.apiData.getReceiptData().subscribe((data) => {
      this.receiptDetails = data.receipt;
    });

    this.GetAllGoods();
  }

  GetAllGoods(){
    this.apiClient.GetAllGoods().subscribe({
      next: (response: any) => {

          this.productList = response;
          console.log("response", response)
      },
      error: (error: any) => {
          console.error("Error fetching data from API:", error);
      },
    });
  }

  replaceDescriptionWithProductName(descriptionId: any): string {
    const product = this.productList.find((p) => p.productId === parseInt(descriptionId));
    return product ? product.productName : "Product name missing";
  }
}
