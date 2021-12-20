import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { IPagination } from '../models/pagination';
import { IProduct } from '../models/product';
import { IBrand } from '../models/brand';
import { ICategory } from '../models/category';
import { ProductsService } from '../services/products.service';
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons';
import { ProductParameters } from '../models/productParameters';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: IProduct[] = [];
  brands: IBrand[] = [];
  categories: ICategory[] = [];
  productParameters = new ProductParameters();
  totalCount: number = 0;

  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: High to Low', value: 'priceD' },
    { name: 'Price: Low to High', value: 'priceA' }
  ];

  faShoppingCart = faShoppingCart;

  constructor(private route: ActivatedRoute, private productsService: ProductsService) { }

  ngOnInit() {
    this.getProductsByCategory()
    this.getProducts();
    this.getBrands();
    this.getCategories();
  }

  getProductsByCategory() {
    this.productsService.getProductsByCategory(this.route.snapshot.paramMap.get('categoryId') || '').subscribe(products => {
      this.products = products;
    })
  }

  getProducts() {
    this.productsService.getProducts(this.productParameters).subscribe(response => {
      if(response) {
        this.products = response.data;
        this.productParameters.pageNumber = response.pageIndex;
        this.productParameters.pageSize = response.pageSize;
        this.totalCount = response.count;
      }
    }, error => {
      console.log(error);
    })
  }

  getBrands() {
    this.productsService.getBrands().subscribe(response => {
      this.brands = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log(error);
    })
  }

  getCategories() {
    this.productsService.getCategories().subscribe(response => {
      this.categories = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log(error);
    })
  }

  brandSelected(brandId: number) {
    this.productParameters.brandId = brandId;
    this.getProducts();
  }

  categorySelected(categoryId: number) {
    this.productParameters.categoryId = categoryId;
    this.getProducts();
  }

  sortSelected(sort: string) {
    this.productParameters.sort = sort;
    this.getProducts();
  }

  pageChanged(event: any) {
    this.productParameters.pageNumber = event.page;
    this.getProducts(); 
  }
}
