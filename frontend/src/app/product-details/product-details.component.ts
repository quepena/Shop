import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from '../models/product';
import { ProductsService } from '../services/products.service';
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct | undefined;
  faShoppingCart = faShoppingCart;

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
