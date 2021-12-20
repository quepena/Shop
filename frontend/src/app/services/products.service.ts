import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IBrand } from '../models/brand';
import { ICategory } from '../models/category';
import { IPagination } from '../models/pagination';
import { IProduct } from '../models/product';
import { ProductParameters } from '../models/productParameters';

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

  getProducts(productParameters: ProductParameters) {
    let params = new HttpParams();
    
    if(productParameters.brandId !== 0) {
      params = params.append('brandId', productParameters.brandId.toString());
    }

    if(productParameters.categoryId !== 0) {
      params = params.append('categoryId', productParameters.categoryId.toString());
    }

    params = params.append('sort', productParameters.sort);
    params = params.append('pageIndex', productParameters.pageNumber.toString());
    params = params.append('pageIndex', productParameters.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl+'products', {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body;
        }, httpOptions)
      )
  }

  getProduct(id: string) {
    return this.http.get<IProduct>(this.baseUrl+'products/'+id, httpOptions)
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl+'products/brands', httpOptions)
  }

  getCategories() {
    return this.http.get<ICategory[]>(this.baseUrl+'products/categories', httpOptions)
  }
}
