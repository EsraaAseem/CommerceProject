import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RequestsComponent } from './requests.component';
import { CategoryComponent } from './category/category.component';
import { EditCategoryComponent } from './category/edit-category/edit-category.component';
import { RequestsRouterModule } from './requests-router.module';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrandComponent } from './brand/brand.component';
import { EditBrandComponent } from './brand/edit-brand/edit-brand.component';
import { ProductComponent } from './product/product.component';
import { EditProductComponent } from './product/edit-product/edit-product.component';



@NgModule({
  declarations: [
    RequestsComponent,
    CategoryComponent,
    EditCategoryComponent,
    BrandComponent,
    EditBrandComponent,
    ProductComponent,
    EditProductComponent
  ],
  imports: [
    CommonModule,NgbModule,BrowserModule,HttpClientModule,RequestsRouterModule,RouterModule,ReactiveFormsModule,FormsModule
  ]
})
export class RequestsModule {
 }
