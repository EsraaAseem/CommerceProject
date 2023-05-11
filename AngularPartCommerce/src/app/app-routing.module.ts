import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { OrderManageComponent } from './order-manage/order-manage.component';
import { BrandComponent } from './requests/brand/brand.component';
import { EditBrandComponent } from './requests/brand/edit-brand/edit-brand.component';
import { CategoryComponent } from './requests/category/category.component';
import { EditCategoryComponent } from './requests/category/edit-category/edit-category.component';
import { EditProductComponent } from './requests/product/edit-product/edit-product.component';
import { ProductComponent } from './requests/product/product.component';
import { Register } from './service/register.model';
import { ShoppingItemsComponent } from './shopping/shopping-items/shopping-items.component';
import { ShoppingComponent } from './shopping/shopping.component';
import { CheckoutComponent } from './order-manage/checkout/checkout.component';
import { CheckoutSuccessComponent } from './order-manage/checkout/checkout-success/checkout-success.component';
import { OrdersComponent } from './order-manage/orders/orders.component';
import { OrderDetailsComponent } from './order-manage/orders/order-details/order-details.component';
const appRoute:Routes=[
  {path:'',redirectTo:'/shopping',pathMatch:'full'},
  {path:'shopping',component:ShoppingComponent},
  {path:'shopping/:id',component:ShoppingItemsComponent},
  {path:'basket',component:OrderManageComponent},
  {path:'login',component:LoginComponent},
  {path:'login/register',component:RegisterComponent},
  {path:'register',component:RegisterComponent},
  {path:'category',component:CategoryComponent},
  {path:'category/:id',component:EditCategoryComponent},
  {path:'brand',component:BrandComponent},
  {path:'brand/:id',component:EditBrandComponent},
  {path:'product',component:ProductComponent},
  {path:'product/:id',component:EditProductComponent},
  {path:"checkout",component:CheckoutComponent},
  {path:"checkout/success",component:CheckoutSuccessComponent},
  {path:"orders",component:OrdersComponent},
  {path:"orders/:id",component:OrderDetailsComponent,data:{breadcrumb:{alias:"OrderDetailed"}}}



];
@NgModule({
  imports: [RouterModule.forRoot(appRoute)],
  exports:[RouterModule]
})

export class AppRoutingModule {};
