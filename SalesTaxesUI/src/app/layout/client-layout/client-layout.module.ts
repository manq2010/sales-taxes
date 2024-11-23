import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ClientLayoutRoutingModule } from "./client-layout-routing.module";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgxSpinnerModule } from "ngx-spinner";
import { MatIconModule } from "@angular/material/icon";
import { HomeComponent } from "src/app/pages/home/home.component";
import { ProductComponent } from "src/app/pages/product/product.component";
import { ReceiptComponent } from "src/app/pages/receipt/receipt.component";
import { HttpClientModule } from "@angular/common/http";
import { AngularMaterialModule } from "src/app/services/angular-material.module";
import { MatTableModule } from "@angular/material/table";
import { MatDialogModule } from "@angular/material/dialog";
import { ViewReceiptComponent } from "src/app/pages/view-receipt/view-receipt.component";
import { AddReceiptComponent } from "src/app/pages/add-receipt/add-receipt.component";

@NgModule({
  declarations: [
    HomeComponent,
    ProductComponent,
    ReceiptComponent,
    ViewReceiptComponent,
    AddReceiptComponent
  ],
  imports: [
    CommonModule,
    ClientLayoutRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxSpinnerModule,
    MatIconModule,
    HttpClientModule,
    AngularMaterialModule,
    MatTableModule,
    MatDialogModule
  ],
})
export class ClientLayoutModule {}
