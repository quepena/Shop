import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product';

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

  getProducts(categoryId: string) {
    return this.http.get<Product[]>(this.baseUrl+'products/category/'+categoryId, httpOptions)
  }

  getProduct(id: string) {
    return this.http.get<Product>(this.baseUrl+'products/'+id, httpOptions)
  }
}
