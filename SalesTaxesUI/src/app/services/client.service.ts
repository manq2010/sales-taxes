import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environment';

const httpOptions = {
  headers: new HttpHeaders({
    "Content-Type": "application/json",
    "Access-Control-Allow-Origin": "*",
  }),
};

@Injectable({
  providedIn: 'root',
})
export class ClientService {
  constructor(private http: HttpClient) {}
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
    }),
  };

  GetPagedAllReceipts(pageNumber: any, pageSize: any) {
    return this.http.get<any>(
      environment.serverAPI + `v1/Lookup/GetPagedAllReceipts?pageNumber=${pageNumber}&pageSize=${pageSize}`,
    );
  }

  GetAllImportedGoods() {
    return this.http.get<any>(
      environment.serverAPI +
        `v1/Lookup/GetAllImportedGoods`,
        this.httpOptions
    );
  }

  GetAllLocalGoods() {
    return this.http.get<any>(
      environment.serverAPI +
        `v1/Lookup/GetAllLocalGoods`,
        this.httpOptions
    );
  }

  GetAllGoods() {
    return this.http.get<any>(
      environment.serverAPI +
        `v1/Lookup/GetAllGoods`,
        this.httpOptions
    );
  }

  GetReceiptById(Id: any) {
    return this.http.get<any>(
      environment.serverAPI + `v1/Receipts/GetReceiptById?id=${Id}`,
    );
  }

  GetAllProductTypes() {
    return this.http.get<any>(
      environment.serverAPI +
        `v1/Lookup/GetAllProductTypes`,
        this.httpOptions
    );
  }

  GetAllTaxTypes() {
    return this.http.get<any>(
      environment.serverAPI +
        `v1/Lookup/GetAllTaxTypes`,
        this.httpOptions
    );
  }

  PostInsertReceipt(body: {}) {
    return this.http.post<any>(
      environment.serverAPI + "v1/Receipts/PostInsertReceipt",
      body
    );
  }
}
