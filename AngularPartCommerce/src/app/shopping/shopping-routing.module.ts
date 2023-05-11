import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ShoppingComponent } from './shopping.component';
import { ShoppingItemsComponent } from './shopping-items/shopping-items.component';
import { ShoppingItemDetailsComponent } from './shopping-item-details/shopping-item-details.component';
const shoppingRoute:Routes=[
  /*{path:'shopping',component:ShoppingComponent,children:[
    {path:'item',component:ShoppingItemsComponent}
  ]}*/
   {path:'shopping',component:ShoppingComponent},
    {path:'shopping/:id',component:ShoppingItemsComponent},
    {path:'shopping/:id/:productId',component:ShoppingItemDetailsComponent},
];
@NgModule({
  imports:[RouterModule.forChild(shoppingRoute)],
  exports:[RouterModule]
})
export class ShoppingRoutingModule { }
