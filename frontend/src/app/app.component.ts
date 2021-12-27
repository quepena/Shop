import { Component, OnInit } from '@angular/core';
import { CartService } from './cart/cart.service';
import { User } from './models/user';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Shop';

  constructor(private accountService: AccountService, private cartService: CartService) {

  }
  ngOnInit(): void {
    this.setCurrentUser();

    const cartId = localStorage.getItem('cart_id');

    if(cartId) {
      this.cartService.getCart(cartId).subscribe(() => {
        console.log('basket');
      }, error => {
        console.log(error);
      })
    }
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user')!);
    this.accountService.setCurrentUser(user);
  }
}
