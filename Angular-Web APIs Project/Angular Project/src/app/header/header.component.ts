import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  
  constructor(private router:Router) {
  }

  ngOnInit(): void {
  }
  goToProducts()
  {
    this.router.navigate(['/product/products']);
  }
  gitProductsInCategory(catId:number)
  {
    this.router.navigate(['/product/productsInCat' , catId]);
  }
  gitProductsInType(typeId:number)
  {
    this.router.navigate(['/product/productsInType' , typeId]);
  }
}
