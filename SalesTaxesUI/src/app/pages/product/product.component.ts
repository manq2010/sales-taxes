import { Component, OnInit } from '@angular/core';
import { ClientService } from 'src/app/services/client.service';

export interface Product {
  productId: number;
  productName: string;
  unitPrice: number;
  isImport: boolean;
}

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  productList: Product[] = [];


  constructor(private apiClient: ClientService) {

  }
  ngOnInit(): void {
    this.GetAllGoods();
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
}
