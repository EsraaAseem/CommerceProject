import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Observable, interval } from 'rxjs';
import { Brand } from '../service/Brand.Model';
import { Category } from '../service/category.model';
import { Product } from '../service/product.model';
import { StdDataServiceService } from '../service/std-dataservice.service';
import { StdServiceService } from '../service/std-service.service';
import { User } from '../service/user.model';
import { ShoppingCart } from '../service/shoppingCart.model';
import { BasketService } from '../service/basket.service';
import { IBasket } from '../service/basket.model';

@Component({
  selector: 'app-nevber',
  templateUrl: './nevber.component.html',
  styleUrls: ['./nevber.component.css']
})
export class NevberComponent implements OnInit{
  open=true;
  basket$:Observable<IBasket>;
  currentUser: User;
  ca:Category;
  catgories:Category[]=[];
  brands:Brand[]=[];
  shoppingCarts:ShoppingCart[]=[];
constructor(private basketService:BasketService,private service:StdServiceService,private router:Router,private serv:StdDataServiceService,private route:ActivatedRoute){}
ngOnInit(): void { 
  this.basket$=this.basketService.basket$;
  this.service.user.subscribe(user => this.currentUser = user);
    //console.log(this.currentUser);
    this.serv.getBrands().subscribe((success)=>{ this.brands=success;});
    this.serv.getCategories().subscribe((success)=>{  this.catgories=success;});
   /*this.serv.getCarts().subscribe((res)=>{
   this.shoppingCarts=res;
    })*/
    if(this.currentUser)
    {
    const basketId= localStorage.getItem("basket_id");
    if(basketId)
    {
     this.basketService.getBasket(basketId)
     .subscribe(()=>{
    //  console.log("current basket")

    },error=>{console.log(error)})
    }
    else{console.log("no basket")}
  }
  }
  clic(ca){window.location.reload();} //
 set(){if(this.open==true) this.open=false; else this.open=true;}
 onLogout(){
  this.service.LogOut();
  this.router.navigate(['/shopping']);} 
}
