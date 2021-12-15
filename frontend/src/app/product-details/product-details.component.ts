import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../models/product';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product: Product | undefined;

  constructor(private productService: ProductsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getProduct();
  }

  getProduct() {
    this.productService.getProduct(this.route.snapshot.paramMap.get('id') || '').subscribe(product => {
      this.product = product;
    })
  }
}
