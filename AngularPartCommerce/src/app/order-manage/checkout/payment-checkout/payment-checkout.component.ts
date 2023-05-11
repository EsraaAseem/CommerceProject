import { AfterViewInit, Component, ElementRef, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NavigationExtras, Router } from '@angular/router';
import { map } from 'rxjs';
import { IBasket } from 'src/app/service/basket.model';
import { BasketService } from 'src/app/service/basket.service';
import { IOrder, IOrderToCreate } from 'src/app/service/order';
declare var Stripe;
@Component({
  selector: 'app-payment-checkout',
  templateUrl: './payment-checkout.component.html',
  styleUrls: ['./payment-checkout.component.css']
})
export class PaymentCheckoutComponent implements OnInit,AfterViewInit,OnDestroy{
  @Input()checkoutForm:FormGroup;
  @ViewChild('cardNumber',{static:true}) cardNumberElement:ElementRef;
  @ViewChild('cardExpiry',{static:true}) cardExpiryElement:ElementRef;
  @ViewChild('cardCvc',{static:true}) cardCvcElement:ElementRef;
  stripe:any;
  cardNumber:any;
  cardExpiry:any;
  cardCvc:any;
  cardErrors:any;
  ordercreate:IOrderToCreate;
  cardHandler=this.onChange.bind(this);
  loading=false;
  cardNumberValid=false;
  cardExpiryValid=false;
  cardCvcValid=false;
  constructor(private basketService:BasketService,private router:Router){}
  
  ngAfterViewInit(): void {
    this.stripe=Stripe('pk_test_51N2OCLEWxjgR87lQq4SwMB3jph7HWMEJZKinyH1ysck6SWofyVZvN4sx1kKjxkNpLpEbFWqcGgxbSD3kYjwHdFan00DC9CPI26');
    const elements=this.stripe.elements();
    this.cardNumber=elements.create('cardNumber');
    this.cardNumber.mount(this.cardNumberElement.nativeElement);
    this.cardNumber.addEventListener('change',this.cardHandler);

    this.cardExpiry=elements.create('cardExpiry');
    this.cardExpiry.mount(this.cardExpiryElement.nativeElement);
    this.cardExpiry.addEventListener('change',this.cardHandler);

    this.cardCvc=elements.create('cardCvc');
    this.cardCvc.mount(this.cardCvcElement.nativeElement);
    this.cardCvc.addEventListener('change',this.cardHandler);

  }
  ngOnInit():void{
  }
   private  getordertoCreate(basket:IBasket)//:IOrderToCreate
  {
    return {
      basketId:basket.id,
      delivaryMethodId:this.checkoutForm.get('delieveryForm').get('delieveryMethod').value,
      shippingToAddress:this.checkoutForm.get('addressForm').value
  };
}
async submitOrder()
{
  this.loading=true;
  const basket=this.basketService.getCurrentBasketValue();
  try{
    const createdOrder=await this.createOrder(basket);
    //const orderToCreate=this.getordertoCreate(basket);
    const paymentResult=await this.confirmPaymentWithStripe(basket);
    //console.log(orderToCreate)
    if(paymentResult.paymentIntent)
    {
      this.basketService.deleteLocalBasket(basket.id);
      const navigationExtras:NavigationExtras={state:createdOrder};
      this.router.navigate(['/checkout/success'],navigationExtras);
    }else{
      console.log('payment error');
    }
this.loading=false;
  }catch(error){
console.log(error)
this.loading=false;
  }
 
}
  private async confirmPaymentWithStripe(basket) {
   return this.stripe.confirmCardPayment(basket.clientSecret,{
      payment_method:{
        card:this.cardNumber,
        billing_details:{
          name:this.checkoutForm.get('paymentForm').get('nameOnCard').value
        }
      }
     });
  }
private async createOrder(basket: IBasket) {
  const orderToCreate=this.getordertoCreate(basket);
  return this.basketService.createOrder(orderToCreate).toPromise();
  }
onChange(event)
{
  if(event.error)
  {
    this.cardErrors=event.error.message;
  }
  else{
    this.cardErrors=null;
  }
  switch(event.elementType)
  {
    case 'cardNumber':
      this.cardNumberValid=event.complete;
      break;
      case 'cardExpiry':
      this.cardExpiryValid=event.complete;
      break;
      case 'cardCvc':
      this.cardCvcValid=event.complete;
      break;
  }
}
ngOnDestroy(): void {
  this.cardNumber.destroy();
  this.cardExpiry.destroy();
  this.cardCvc.destroy();

}
}
