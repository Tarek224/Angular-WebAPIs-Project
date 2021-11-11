import { Component, OnInit } from '@angular/core';
import { Product } from '../SharedClasses/product';
import { ProductServiceService } from '../Services/product-service.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-products-in-category',
  templateUrl: './products-in-category.component.html',
  styleUrls: ['./products-in-category.component.scss']
})
export class ProductsInCategoryComponent implements OnInit {
  productsList:Product[] = [];
  errorMsg :string ="";
  totalLength:any;
  page:number = 1;
  imgSource:string = "../../assets/images/Products/";
  categoryID:any;

  constructor(private prodserv:ProductServiceService , private router:Router , private routActive:ActivatedRoute) { }

  ngOnInit(): void {
    this.categoryID = this.routActive.snapshot.paramMap.get("catId");

    this.prodserv.getProductsInCategory(this.categoryID).subscribe(
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
