import { Component, OnInit } from '@angular/core';
import { ProductServiceService } from '../Services/product-service.service';
import { Product } from '../SharedClasses/product';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  constructor(private prodserv:ProductServiceService , private router:Router , private routActive:ActivatedRoute) { }

  ngOnInit(): void {
  }

  gitProductsInType(typeId:number)
  {
    this.router.navigate(['/product/productsInType' , typeId]);
  }
  
  addToCart(product_ID:number)
  {
    this.router.navigate(['/cart' , product_ID]);
  }
}