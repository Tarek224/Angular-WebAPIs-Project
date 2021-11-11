import { Component, OnInit } from '@angular/core';
import { Product } from '../SharedClasses/product';
import { ProductServiceService } from '../Services/product-service.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-all-products',
  templateUrl: './all-products.component.html',
  styleUrls: ['./all-products.component.scss']
})
export class AllProductsComponent implements OnInit {

  productsList:Product[] = [];
  errorMsg :string ="";
  totalLength:any;
  page:number = 1;
  imgSource:string = "../../assets/images/Products/";
  
  constructor(private prodserv:ProductServiceService , private router:Router , private routActive:ActivatedRoute) { }

  ngOnInit(): void {

    this.prodserv.getProducts().subscribe(
      data => {
        this.productsList = data;
        this.totalLength = data.length;
      },
      error => {
        this.errorMsg = error;
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
