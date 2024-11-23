

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddReceiptComponent } from 'src/app/pages/add-receipt/add-receipt.component';
import { HomeComponent } from 'src/app/pages/home/home.component';
import { ProductComponent } from 'src/app/pages/product/product.component';
import { ReceiptComponent } from 'src/app/pages/receipt/receipt.component';
import { ViewReceiptComponent } from 'src/app/pages/view-receipt/view-receipt.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'products', component: ProductComponent },
  { path: 'receipts', component: ReceiptComponent },
  { path: 'receipts/view', component: ViewReceiptComponent },
  { path: 'receipts/add', component: AddReceiptComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientLayoutRoutingModule {}
