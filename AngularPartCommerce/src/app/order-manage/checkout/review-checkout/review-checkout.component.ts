import { CdkStepper } from '@angular/cdk/stepper';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { IBasket } from 'src/app/service/basket.model';
import { BasketService } from 'src/app/service/basket.service';
import { ShoppingCart } from 'src/app/service/shoppingCart.model';
import { StdDataServiceService } from 'src/app/service/std-dataservice.service';
import { StdServiceService } from 'src/app/service/std-service.service';
import { User } from 'src/app/service/user.model';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-review-checkout',
  templateUrl: './review-checkout.component.html',
  styleUrls: ['./review-checkout.component.css']
})
export class ReviewCheckoutComponent implements OnInit{
  @Input() appStepper:CdkStepper;
  currentUser: User;
  path=environment.baseurl;
  basket$:Observable<IBasket>;
  constructor(private basketService:BasketService,private service:StdDataServiceService,private serv:StdServiceService,private router:Router) {
  }
   ngOnInit(): void {
    this.basket$=this.basketService.basket$;
    this.serv.user.subscribe(user => this.currentUser = user);
  }
  createPaymentIntend()
  {
    return this.basketService.createPaymentIntend().subscribe((res)=>{
      console.log(res)
      this.appStepper.next();
    },error=>{console.log(error)})
  }
}
