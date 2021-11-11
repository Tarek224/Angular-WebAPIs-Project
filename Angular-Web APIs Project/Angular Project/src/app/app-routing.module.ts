import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductComponent } from './product/product.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductsTypeComponent } from './products-type/products-type.component';
import { ProductsInCategoryComponent } from './products-in-category/products-in-category.component';
import { AllProductsComponent } from './all-products/all-products.component';
import { UserRegisterationComponent } from './user-registeration/user-registeration.component';
import { CartComponent } from './cart/cart.component';

const routes: Routes = [
  {path:'',redirectTo:'/home',pathMatch:'full'},
  {path:'home' , component:HomeComponent},
  {path:'product' , component:ProductComponent ,
    children:[
      {path:'products' , component:AllProductsComponent},
      {path:'productsInType/:typeId' , component:ProductsTypeComponent},
      {path:'productsInCat/:catId' , component:ProductsInCategoryComponent }
    ]},
  {path:'productdetails/:id' , component:ProductDetailsComponent },
  {path:'register' , component:UserRegisterationComponent},
  {path:'cart/:product_ID' , component:CartComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
