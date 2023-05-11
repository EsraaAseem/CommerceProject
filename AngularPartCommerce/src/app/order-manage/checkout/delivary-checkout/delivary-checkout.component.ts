import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IDelievery } from 'src/app/service/IDelievery.model';
import { BasketService } from 'src/app/service/basket.service';
import { ShoppingCart } from 'src/app/service/shoppingCart.model';
import { StdDataServiceService } from 'src/app/service/std-dataservice.service';

@Component({
  selector: 'app-delivary-checkout',
  templateUrl: './delivary-checkout.component.html',
  styleUrls: ['./delivary-checkout.component.css']
})
export class DelivaryCheckoutComponent implements OnInit{
  @Input() checkoutForm:FormGroup
  deliveryMethods:IDelievery[]=[];
  shoppingCart:ShoppingCart[]=[];

  constructor(private service:StdDataServiceService,private basketService:BasketService){}
  ngOnInit(): void {
    this.service.getDeliveryMethods().subscribe((res)=>{
      this.deliveryMethods=res;
    //  console.log(res);
    },error=>{console.log(error)})
  }
  setdelivaryPrice(delievery:IDelievery)
  {
    this.basketService.setShippingPrice(delievery);
  }
 /* getpre(pre)
  {
    this.service.getCarts().subscribe((res)=>{
      this.subtotal=0;
      this.shoppingCart=res;
      for(let shop of this.shoppingCart)
      {
        this.subtotal+=shop.count*shop.product.price;
      }
      this.subtotal+=pre;
      this.service.basket=this.subtotal;
      console.log(this.service.basket);
    })
  }*/
}
