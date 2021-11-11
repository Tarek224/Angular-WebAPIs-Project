import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CartServiceService } from '../Services/cart-service.service';
import { Cart } from '../SharedClasses/Cart';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  CartAdded:Cart = new Cart();
  cartID:any;

  constructor(private routActive:ActivatedRoute , private cart:CartServiceService) { }

  ngOnInit(): void {
    this.cartID = this.routActive.snapshot.paramMap.get("product_ID");

    this.cart.addToCart(this.cartID).subscribe( data => {
      this.CartAdded = data;
    })
  }

}
