import { Component, OnInit } from '@angular/core';
// import { ICategory } from '../models/category';
import { CategoriesService } from '../services/categories.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {
  // categories: ICategory[] = [];

  constructor(private categoriesService: CategoriesService) { }

  ngOnInit(): void {
    // this.getCategories()
  }

  // getCategories() {
  //   this.categoriesService.getCategories().subscribe(categories => {
  //     this.categories = categories;
  //   })
  // }

}
