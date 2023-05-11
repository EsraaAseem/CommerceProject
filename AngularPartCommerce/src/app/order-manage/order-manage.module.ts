import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { ShoppingRoutingModule } from '../shopping/shopping-routing.module';
import { OrderManageComponent } from './order-manage.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { StepperComponent } from './stepper/stepper.component';
import { CdkStepperModule } from '@angular/cdk/stepper';
import {AddressCheckoutComponent} from './checkout/address-checkout/address-checkout.component';
import { DelivaryCheckoutComponent } from './checkout/delivary-checkout/delivary-checkout.component';
import { ReviewCheckoutComponent } from './checkout/review-checkout/review-checkout.component';
import { PaymentCheckoutComponent } from './checkout/payment-checkout/payment-checkout.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from '../service/text-input/text-input.component';
import { OrderTotalComponent } from './order-total/order-total.component';
import { CheckoutSuccessComponent } from './checkout/checkout-success/checkout-success.component';
import { OrdersComponent } from './orders/orders.component';
import { OrderDetailsComponent } from './orders/order-details/order-details.component';



@NgModule({
  declarations: [
    OrderManageComponent,
    CheckoutComponent,
    StepperComponent,
    DelivaryCheckoutComponent,
    ReviewCheckoutComponent,
    PaymentCheckoutComponent,
    AddressCheckoutComponent,
    TextInputComponent,
    OrderTotalComponent,
    CheckoutSuccessComponent,
    OrdersComponent,
    OrderDetailsComponent
    
  ],
  imports: [
    CommonModule,NgbModule,RouterModule,ShoppingRoutingModule,CdkStepperModule, FormsModule,
    ReactiveFormsModule
    
  ]
})
export class OrderManageModule { }
