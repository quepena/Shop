import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { AccountService } from '../services/account.service';
import { faShoppingCart } from '@fortawesome/free-solid-svg-icons';
import { CartService } from '../cart/cart.service';
import { ICart } from '../models/cart';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  faShoppingCart = faShoppingCart
  cart$: Observable<ICart>;

  constructor(public accountService: AccountService, private cartService: CartService) { }

  ngOnInit() {
    // this.cart$ = this.cartService.cart$;
  }

  login() {
    this.accountService.login(this.model).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    })
  }

  logout() {
    this.accountService.logout();
  }
}
