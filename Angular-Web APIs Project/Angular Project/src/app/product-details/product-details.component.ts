import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Product } from '../SharedClasses/product';
import { ProductServiceService } from '../Services/product-service.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  productID:any;
  productItem:Product = {Product_ID:0 , Product_Color:"" , Product_Image:"" , Product_Name:"" , Product_Price:0 , Product_Size:"" , Description:"" , Category_Name:""};
  imgSource:string = "../../assets/images/Products/";

  constructor(private routActive:ActivatedRoute , private product:ProductServiceService , private router:Router) { }

  ngOnInit(): void {
    this.productID = this.routActive.snapshot.paramMap.get("id");

    this.product.getProductWithId(this.productID).subscribe(
      data => {
        this.productItem = data;
      });
  }
  addToCart(product_ID:number)
  {
    this.router.navigate(['/cart' , product_ID]);
  }
}
