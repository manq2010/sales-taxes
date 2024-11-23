import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {
  constructor(private router: Router) {}

  ngOnInit(): void {}

  navigateToProducts() {
    this.router.navigate(['/products']);
  }

  navigateToReceipts() {
    this.router.navigate(['/receipts']);
  }

  navigateToHome() {
    this.router.navigate(['/home']);
  }
}
