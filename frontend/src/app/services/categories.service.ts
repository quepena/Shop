import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
// import { ICategory } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  // getCategories() {
  //   return this.http.get<Category[]>(this.baseUrl+'categories')
  // }

  // getCategory(id: string) {
  //   return this.http.get<Category>(this.baseUrl+'categories/'+id)
  // }
}
