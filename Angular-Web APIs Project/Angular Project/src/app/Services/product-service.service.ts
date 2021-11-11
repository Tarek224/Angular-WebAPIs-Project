import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../SharedClasses/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {

  productsUrl:string = "https://localhost:44353/api/products";
  productWithIdUrl:string = "https://localhost:44353/api/productdetails/";
  ProductsInCategoryUrl:string = "https://localhost:44353/api/InCategory/";
  ProductsWithTypeUrl:string = "https://localhost:44353/api/WithType/";

  constructor(private http:HttpClient) { }

  getProducts():Observable<Product[]>
  {
    return this.http.get<Product[]>(this.productsUrl);
  }
  getProductWithId(id:number):Observable<Product>
  {
    return this.http.get<Product>(`${this.productWithIdUrl}${id}`);
  }
  getProductsInCategory(catId:number):Observable<Product[]>
  {
    return this.http.get<Product[]>(`${this.ProductsInCategoryUrl}${catId}`);
  }
  getProductsWithType(typeId:number):Observable<Product[]>
  {
    return this.http.get<Product[]>(`${this.ProductsWithTypeUrl}${typeId}`);
  }
}
