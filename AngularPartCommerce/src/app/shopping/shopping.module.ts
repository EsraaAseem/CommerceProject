import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShoppingComponent } from './shopping.component';
import { ShoppingItemsComponent } from './shopping-items/shopping-items.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { ShoppingRoutingModule } from './shopping-routing.module';
import { ShoppingItemDetailsComponent } from './shopping-item-details/shopping-item-details.component';
import { FormsModule } from '@angular/forms';
@NgModule({
    declarations: 
    [
     ShoppingComponent,
     ShoppingItemsComponent,
     ShoppingItemDetailsComponent
    ],
    imports: [
      CommonModule,NgbModule,RouterModule,ShoppingRoutingModule,FormsModule
    ]
  })
export class ShoppingModule
{ 
 
};
