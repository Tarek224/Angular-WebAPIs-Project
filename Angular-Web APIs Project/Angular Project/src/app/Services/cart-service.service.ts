import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cart } from '../SharedClasses/Cart';
import { Observable } from 'rxjs';
import { UserLogin, User } from '../SharedClasses/User';

@Injectable({
  providedIn: 'root'
})
export class CartServiceService {

  user:User = { User_Email: localStorage.getItem("AuthenticatedUser") }

  _urlAddCart:string = "https://localhost:44353/api/addcart/";
  _urlProductsInCart:string = "https://localhost:44353/api/cart/products/"

  constructor(private http:HttpClient) { }

  addToCart(Product_ID:number ):Observable<Cart>
  {
    return this.http.post<Cart>(`${this._urlAddCart}${Product_ID}` , null);
  }
  getProductInCart()
  {

  }
}
