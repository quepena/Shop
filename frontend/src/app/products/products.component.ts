import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: any;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.getProducts()
  }

  getProducts() {
    this.http.get("https://localhost:5001/api/products").subscribe(response => {
      this.products = response;
    }, error => {
      console.log(error);
    })
  }
}
