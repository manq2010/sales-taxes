import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { FormGroup } from '@angular/forms';

interface User {}
@Injectable({
  providedIn: 'root',
})
export class Dataservice {
  private form!: FormGroup;

  private receiptSubject = new BehaviorSubject<any | null>(null);

  // Observable to which components can subscribe
  public receiptObservable$ = this.receiptSubject.asObservable();

  constructor() {}

  getReceiptData(): Observable<any> {
    return this.receiptObservable$;
  }

  setReceiptData(data: any): void {
    this.receiptSubject.next(data);
  }

  setForm(form: FormGroup) {
    this.form = form;
  }

  clearForm() {
    if (this.form) {
      this.form.reset();
    }
  }
}
