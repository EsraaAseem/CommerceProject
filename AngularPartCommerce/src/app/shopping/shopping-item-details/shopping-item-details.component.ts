import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { BasketService } from 'src/app/service/basket.service';
import { Product } from 'src/app/service/product.model';
import { ShoppingCart } from 'src/app/service/shoppingCart.model';
import { ShoppingCartRequest } from 'src/app/service/shoppingCartRequest';
import { StdDataServiceService } from 'src/app/service/std-dataservice.service';
import { StdServiceService } from 'src/app/service/std-service.service';
import { User } from 'src/app/service/user.model';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-shopping-item-details',
  templateUrl: './shopping-item-details.component.html',
  styleUrls: ['./shopping-item-details.component.css']
})
export class ShoppingItemDetailsComponent implements OnInit{
  product:Product;
  index=''
  currentUser: User;
  path=environment.baseurl;
//@ViewChild('count')count:number;
 constructor(private basketService:BasketService,private service:StdDataServiceService,private route:ActivatedRoute,private serv:StdServiceService){}
  ngOnInit(): void {
    this.serv.user.subscribe(user => this.currentUser = user);
    this.route.params.subscribe((params:Params)=>{
      this.index=params['productId'];
      this.service.getProduct(this.index).subscribe((res)=>{
        this.product=res;
       // console.log(this.product)
       }); });
  }
  shoppingCart:ShoppingCartRequest={
    productId:'',
    applicationUserId:'',
    count:1,
    price:0

  }
getimg(im)
{
  return this.service.getProImgPath(im);
}
onSubmitt(count){
  this.basketService.addItemToBasket(this.product,count);
 /* this.shoppingCart.productId=this.product.id;
  this.shoppingCart.count=count;
 this.service.AddShopping(this.shoppingCart).subscribe((res)=>{
    console.log(res)
  })*/
}
}

//this.service.getProduct(this.index).subscribe((res)=>{console.log(res) });