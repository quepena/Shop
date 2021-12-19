import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { IPagination } from '../models/pagination';
import { IProduct } from '../models/product';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: IProduct[] = [];

  constructor(private route: ActivatedRoute, private productsService: ProductsService) { }

  ngOnInit() {
    this.getProductsByCategory()
    this.getProducts();
  }

  getProductsByCategory() {
    this.productsService.getProductsByCategory(this.route.snapshot.paramMap.get('categoryId') || '').subscribe(products => {
      this.products = products;
    })
  }

  getProducts() {
    this.productsService.getProducts().subscribe(response => {
      this.products = response.data;
    }, error => {
      console.log(error);
    })
  }
}
