import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BasketService } from 'src/app/service/basket.service';
import { StdDataServiceService } from 'src/app/service/std-dataservice.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit{
  checkoutForm:FormGroup
  constructor(private fb:FormBuilder,private serv:StdDataServiceService,private basketService:BasketService){}
  ngOnInit(): void {
    this.CreateCheckoutForm();
    this.getAddresFormValue();
    this.getDeliveryMethodsValue();
  }
   CreateCheckoutForm()
   {
    this.checkoutForm=this.fb.group({
      addressForm:this.fb.group({
        name: [null,Validators.required],
        city: [null,Validators.required],
        streetAddress: [null,Validators.required],
        postalCode: [null,Validators.required],
        phoneNumber: [null,Validators.required],
      }),
      delieveryForm:this.fb.group({
        delieveryMethod:[null,Validators.required]
      }),
      paymentForm:this.fb.group({
        nameOnCard:[null,Validators.required]
      })
    })
   }
   getAddresFormValue()
   {
    this.serv.getUserAddress().subscribe((address)=>{
      if(address)
      {
        this.checkoutForm.get('addressForm').patchValue(address);
      }
    },error=>{console.log(error)})
   }
   getDeliveryMethodsValue()
   {
    const basket=this.basketService.getCurrentBasketValue();
    if(basket.deliveryMethodId!==null)
    {
      this.checkoutForm.get('delieveryForm').get('delieveryMethod').patchValue(basket.deliveryMethodId.toString());
    }
   }
}
