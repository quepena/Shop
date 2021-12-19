import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IPagination } from '../models/pagination';
import { IProduct } from '../models/product';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer' + JSON.parse(localStorage.getItem('user') || '{}').token
  })
}

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProductsByCategory(categoryId: string) {
    return this.http.get<IProduct[]>(this.baseUrl+'products/category/'+categoryId, httpOptions)
  }

  getProducts() {
    return this.http.get<IPagination>(this.baseUrl+'products', httpOptions)
  }

  getProduct(id: string) {
    return this.http.get<IProduct>(this.baseUrl+'products/'+id, httpOptions)
  }
}
