import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Brand } from 'src/app/service/Brand.Model';
import { BasketService } from 'src/app/service/basket.service';
import { Product } from 'src/app/service/product.model';
import { ShoppingCartRequest } from 'src/app/service/shoppingCartRequest';
import { StdDataServiceService } from 'src/app/service/std-dataservice.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-shopping-items',
  templateUrl: './shopping-items.component.html',
  styleUrls: ['./shopping-items.component.css']
})
export class ShoppingItemsComponent implements OnInit{
  path=environment.baseurl;
  brands:Brand[]=[];
  products:Product[]=[]
  pros:Product[]=[]
  index:'';
  shoppingCart:ShoppingCartRequest={
    productId:'',
    applicationUserId:'',
    count:1,
    price:0

  }
  constructor(private basketService:BasketService,private route:ActivatedRoute,private service:StdDataServiceService){}
  ngOnInit(): void {
    this.service.getBrands().subscribe((success)=>{ this.brands=success;});
    this.route.params.subscribe((params:Params)=>{
      this.index=params['id'];}
      );
    
      console.log(this.index)
      this.onget();
  }
  addShopping(pro){
    this.basketService.addItemToBasket(pro,1);

   /* this.shoppingCart.productId=pro.id;
    this.service.AddShopping(this.shoppingCart).subscribe((res)=>{
      console.log(res)
    })*/
  }
  onget(){
    this.service.getProducts(this.index).subscribe((success)=>{
      this.products=success;
      this.pros=success;
      console.log(success);
    });
  }
  getprobran(brandId){
    this.service.getProducts(this.index,brandId).subscribe((success)=>{
      this.products=success;
      console.log(success);
    });
    
  }
}
