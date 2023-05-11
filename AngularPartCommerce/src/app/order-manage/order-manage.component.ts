import { Component, OnInit } from '@angular/core';
import { StdDataServiceService } from '../service/std-dataservice.service';
import { User } from '../service/user.model';
import { StdServiceService } from '../service/std-service.service';
import { ShoppingCart } from '../service/shoppingCart.model';
import { environment } from 'src/environments/environment';
import { ShoppingCartRequest } from '../service/shoppingCartRequest';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { IBasket, IBasketItem } from '../service/basket.model';
import { BasketService } from '../service/basket.service';

@Component({
  selector: 'app-order-manage',
  templateUrl: './order-manage.component.html',
  styleUrls: ['./order-manage.component.css']
})
export class OrderManageComponent implements OnInit{
  /*shoppingCartrequest:ShoppingCartRequest={
    productId:'',
    applicationUserId:'',
    count:1,
    price:0

  }*/
  /**
   *
   */
  constructor(private basketService:BasketService,private service:StdDataServiceService,private serv:StdServiceService,private router:Router) {
  }
  currentUser: User;
  //shoppingCart:ShoppingCart[]=[];
  path=environment.baseurl;
  subtotal=0;
 basket$:Observable<IBasket>;
 
  ngOnInit(): void {
    this.basket$=this.basketService.basket$;
    this.serv.user.subscribe(user => this.currentUser = user);
   /* this.service.getCarts().subscribe((res)=>{
      this.shoppingCart=res;
      console.log(this.shoppingCart)
      for(let shop of this.shoppingCart)
      {
        this.subtotal+=shop.count*shop.product.price;
      }
      this.service.basket=this.subtotal;
    })*/

  }
  increamentItem(item:IBasketItem)
  {
    this.basketService.IncreamentItemQuentity(item)
  }
  decreamentItem(item:IBasketItem)
  {
    this.basketService.decreamentItemQuentity(item)
  }
  removeItem(item:IBasketItem)
  {
    this.basketService.removeItemFromBasket(item)
  }
  onsub(){
    this.router.navigate(['/checkout']);
  }
  /*
  Increase(cart){
    this.shoppingCartrequest.productId=cart;
    this.service.IncreaseShopping(this.shoppingCartrequest).subscribe((res)=>{
    });
    this.service.getCarts().subscribe((res)=>{
      this.shoppingCart=res;
    })


    this.service.getCarts().subscribe((res)=>{
      this.subtotal=0;
      this.shoppingCart=res;
      for(let shop of this.shoppingCart)
      {
        this.subtotal+=shop.count*shop.product.price;
      }
    })

  }
  Decrease(cart){
    this.shoppingCartrequest.productId=cart;
    this.service.DecreaseShopping(this.shoppingCartrequest).subscribe((res)=>{console.log(res)});
    this.service.getCarts().subscribe((res)=>{
      this.shoppingCart=res;
    })

    this.service.getCarts().subscribe((res)=>{
      this.subtotal=0;
      this.shoppingCart=res;
      for(let shop of this.shoppingCart)
      {
        this.subtotal+=shop.count*shop.product.price;
      }
    })

  }*/
 
}
