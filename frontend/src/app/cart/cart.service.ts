import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Cart, ICart, ICartItem } from '../models/cart';
import { IProduct } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  baseUrl = environment.apiUrl;
  private cartSource = new BehaviorSubject<ICart | null>(null);
  cart$ = this.cartSource.asObservable();

  constructor(private http: HttpClient) { }

  getCart(id: string) {
    return this.http.get<ICart>(this.baseUrl + 'cart?id=' + id).pipe(map((cart: ICart) => {
      this.cartSource.next(cart);
    }));
  }

  setCart(cart: ICart) {
    return this.http.post<ICart>(this.baseUrl + 'cart', cart).subscribe((response: ICart) => {
      this.cartSource.next(response);
      console.log(response);
      
    }, error => {
      console.log(error);
    })
  }

  getCurrentCartValue() {
    return this.cartSource.value;
  }


  //??????
  // addItem(item: IProduct, quantity = 1) {
  //   const itemToAdd: ICartItem = this.mapProductItemToCartItem(item, quantity);
  //   const cart = this.getCurrentCartValue() ?? this.createCart();
  //   if (cart) {
  //     if(!cart?.items) { //?????
  //       this.addOrUpdateItem(cart.items, itemToAdd, quantity);
  //       this.setCart(cart);
  //      }
  //   }
  // }

  private addOrUpdateItem(items: ICartItem[], itemToAdd: ICartItem, quantity: number): ICartItem[] | undefined {
    const index = items.findIndex(i => i.id === itemToAdd.id);
    if (index === -1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity;
    }

    return items;
  }

  private createCart(): ICart | null {
    const cart = new Cart();
    localStorage.setItem('cart_id', cart.id);
    return cart;
  }

  private mapProductItemToCartItem(item: IProduct, quantity: number): ICartItem {
    return {
      id: item.id,
      productName: item.name,
      price: item.price,
      image: item.image,
      quantity,
      category: item.category,
      brand: item.brand
    }
  }
}

