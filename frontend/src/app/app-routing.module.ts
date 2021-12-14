import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductsComponent } from './products/products.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {path: 'products', component: ProductsComponent, pathMatch: 'full'},
  {path: 'products/:id', component: ProductDetailsComponent},
  // {path: '**', component: ProductsComponent, pathMatch: 'full'},
  {path: 'account/register', component: RegisterComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
