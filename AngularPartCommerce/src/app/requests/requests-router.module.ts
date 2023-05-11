import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { RequestsComponent } from './requests.component';
import { CategoryComponent } from './category/category.component';
import { EditCategoryComponent } from './category/edit-category/edit-category.component';
import { EditBrandComponent } from './brand/edit-brand/edit-brand.component';
import { EditProductComponent } from './product/edit-product/edit-product.component';
const categoryRout:Routes=[
  {path:'Add-category',component:EditCategoryComponent},
  {path:'Add-Brand',component:EditBrandComponent},
  {path:'Add-product',component:EditProductComponent}
]


@NgModule({
  declarations: [],
  imports: [
    CommonModule,RouterModule.forChild(categoryRout)
  ],
  exports:[RouterModule]
})
export class RequestsRouterModule { }
