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

export interface Receipt {
  receiptId: number;
  clientName: string;
  clientEmail: string;
  totalTaxes: number;
  totalCost: number;
  createdAt: string;
}

@Component({
  selector: 'app-receipt',
  templateUrl: './receipt.component.html',
  styleUrls: ['./receipt.component.css'],
})
export class ReceiptComponent implements OnInit {
  displayedColumns: string[] = [
    'receipt_id',
    'client_name',
    'client_email',
    'created_at',
    'total_taxes',
    'total_cost',
    'action',
  ];

  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  @ViewChild('picker', { static: false }) picker!: MatDatepicker<Date>;
  @ViewChild(MatSort, { static: true }) sort!: MatSort;

  dataSource = new MatTableDataSource<Receipt>();
  selection = new SelectionModel<Receipt>(true, []);

  receiptList: Receipt[] = [];

  pageSize = 5;
  pageSizeStore = 5;
  currentPage = 0;
  currentPageStore = 0;

  TotalRecords: any = 0;
  filteredData: any = '';

  date: Date;

  constructor(
    private apiClient: ClientService,
    private apiData: Dataservice,
    public dialog: MatDialog,
    private router: Router,
    private spinner: NgxSpinnerService,
    public datePipe: DatePipe
  ) {
    this.dataSource.filterPredicate = (data, filter: string) =>
      !filter || data.createdAt.includes(filter);

    this.date = new Date();
  }

  ngOnInit(): void {
    this.GetAllReceipts();
  }

  GetAllReceipts(page: number = 1) {
    var currentPage: number = Number(sessionStorage.getItem('currentPage'));
    var pageSize: number = Number(sessionStorage.getItem('pageSize'));

    if (currentPage == 0) {
      currentPage = this.currentPage;
    } else {
      this.currentPage = currentPage;
    }

    if (pageSize == 0) {
      pageSize = this.pageSize;
    } else {
      this.pageSize = pageSize;
    }

    this.apiClient
      .GetPagedAllReceipts(this.currentPage + page, this.pageSize)
      .subscribe({
        next: (response: any) => {
          this.spinner.hide();

          console.log('response', response);
          this.receiptList = response.data;

          sessionStorage.removeItem('currentPage');
          sessionStorage.removeItem('pageSize');

          this.TotalRecords = response.totalRecords;

          setTimeout(() => {
            this.paginator.pageIndex = this.currentPage;
            this.paginator.length = response.totalRecords;
          });

          this.dataSource = new MatTableDataSource(this.receiptList);
          this.dataSource.paginator = this.paginator;
        },
        error: (error) => {
          console.error('Error fetching data from API:', error);
        },
      });
  }

  pageChanged(event: PageEvent) {
    this.pageSize = event.pageSize;
    this.currentPage = event.pageIndex;

    this.GetAllReceipts();

    if (this.dataSource) {
      this.dataSource.filterPredicate = (data: any, filter: string) =>
        data.name.indexOf(filter) || data.Status.indexOf(filter) != -1;
    }
  }

  createReceipt(){
    this.router.navigate(['/receipts/add']);
  }

  navigateToViewReceipt(receiptId: number) {
    sessionStorage.setItem('currentPage', `${this.currentPage}`);
    sessionStorage.setItem('pageSize', `${this.pageSize}`);
  
    this.apiClient.GetReceiptById(receiptId).subscribe(
      (response: any) => {
        this.apiData.setReceiptData(response.detailDescription);
        this.router.navigate(["/receipts/view"]);
      },
      (error) => {
        console.error("Error in fetching data:", error);
      }
    );
  }
}
