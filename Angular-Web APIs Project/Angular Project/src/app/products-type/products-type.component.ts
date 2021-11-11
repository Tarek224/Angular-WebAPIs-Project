import { Component, OnInit } from '@angular/core';
import { Product } from '../SharedClasses/product';
import { ProductServiceService } from '../Services/product-service.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-products-type',
  templateUrl: './products-type.component.html',
  styleUrls: ['./products-type.component.scss']
})
export class ProductsTypeComponent implements OnInit {

  productsList:Product[] = [];
  errorMsg :string ="";
  totalLength:any;
  page:number = 1;
  imgSource:string = "../../assets/images/Products/";
  categoryTypeID:any;

  constructor(private prodserv:ProductServiceService , private router:Router , private routActive:ActivatedRoute) { }

  ngOnInit(): void {

    this.categoryTypeID = this.routActive.snapshot.paramMap.get("typeId");
    
    this.prodserv.getProductsWithType(this.categoryTypeID).subscribe(
      data => {
        this.productsList = data;
        this.totalLength = data.length;
      })
  }

  goToProductDetails(product:Product)
  {
    this.router.navigate(['/productdetails' , product.Product_ID]);
  }

  addToCart(product_ID:number)
  {
    this.router.navigate(['/cart' , product_ID]);
  }
}
