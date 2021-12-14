import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: Product[] = [];

  constructor(private http: HttpClient, private router: Router, private productsService: ProductsService) { }

  ngOnInit() {
    this.getProducts()
  }

  getProducts() {
    this.productsService.getProducts().subscribe(products => {
      this.products = products;
    })
  }
}
