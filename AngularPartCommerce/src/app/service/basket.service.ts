import { Injectable } from '@angular/core';
import { Basket, IBasket, IBasketItem, IBasketTotals } from './basket.model';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Product } from './product.model';
import { StdServiceService } from './std-service.service';
import { IDelievery } from './IDelievery.model';
import { IOrderToCreate } from './order';

@Injectable({
  providedIn: 'root'
})
export class BasketService {  
  shipping=0;
  baseapiurl:string=environment.baseurl;
  private basketsource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketsource.asObservable();
  private basketTotalsource = new BehaviorSubject<IBasketTotals>(null);
  basketTotal$ = this.basketTotalsource.asObservable();
  constructor(private http:HttpClient,private current:StdServiceService) {}
  createPaymentIntend()
  {
    return this.http.post(this.baseapiurl+'/Payment/'+this.getCurrentBasketValue().id,{}).pipe(
      map((basket:IBasket)=>{
        this.basketsource.next(basket);
        console.log(this.getCurrentBasketValue())
      })
    )
  }
  setShippingPrice(delieveryMethod:IDelievery)
  {
    this.shipping=delieveryMethod.price;
    const basket=this.getCurrentBasketValue();
    basket.deliveryMethodId=delieveryMethod.id;
    basket.shippingPrice=delieveryMethod.price;
    this.calculateTotal();
    this.setBasket(basket);
  }
  getBasket(id:string){
    return this.http.get(this.baseapiurl+'/Basket?id='+id).pipe(
      map((basket:IBasket)=>{
        this.basketsource.next(basket)
        this.shipping=basket.shippingPrice
        this.calculateTotal();
       //console.log(this.getCurrentBasketValue())
      })
    )
      }
      setBasket(basket:IBasket){
        return this.http.post(this.baseapiurl+'/Basket',basket).subscribe((response:IBasket)=>{
          this.basketsource.next(response)
          this.calculateTotal();
          //console.log(this.getCurrentBasketValue())
        },error=>{console.log(error)})
      }
      getCurrentBasketValue(){
        return this.basketsource.value;
      }
      checkId(basketid:string)
      {
        return this.http.get(this.baseapiurl+'/checkId?id='+basketid)
      }
      addItemToBasket(item:Product,quentity=1)
      {
       const itemToAdd:IBasketItem=this.mapProductItemToBasketItem(item,quentity);
       const basket=this.getCurrentBasketValue() ?? this.createBasket();
     //  console.log(basket)
    /* console.log(basket);
     console.log(basket.items)
     console.log(itemToAdd)*/
       basket.items=this.addOrUpdateItem(basket.items,itemToAdd,quentity);
      this.setBasket(basket);
      }
      private createBasket():IBasket
      {
       const basket=new Basket

       basket.items=[]
       basket.id=this.current.userValue.userName;
      localStorage.setItem('basket_id',basket.id);
       return basket;
      }
      addOrUpdateItem(items:IBasketItem[],itemAdd:IBasketItem,quentity:number):IBasketItem[]
      {
                 
          const index=items.findIndex(i=>i.id==itemAdd.id);
         //console.log(index);
        if(index==-1)
        {
          itemAdd.count=quentity;
          items.push(itemAdd);
        }
        else{
           items[index].count+=quentity;
        }
        return items
      }
      private mapProductItemToBasketItem(item:Product,count:number):IBasketItem
      {
         return{
          id:item.id,
          title:item.title,
          imageUrl:item.imageUrl,
          price:item.price,
          count,
          category:item.category.name,
          brand:item.brand.name,
         }
      }
      private calculateTotal()
      {
        const basket=this.getCurrentBasketValue();
        const shipping=this.shipping;
        const subTotal=basket.items.reduce((a,b)=>(b.price * b.count)+a,0);
        const total=subTotal+shipping;
        this.basketTotalsource.next({shipping,total,subTotal})
      }
      IncreamentItemQuentity(item:IBasketItem)
      {
        const basket=this.getCurrentBasketValue();
        const finditemIndex=basket.items.findIndex(i=>i.id===item.id)
        basket.items[finditemIndex].count++;
        this.setBasket(basket);
      }
      decreamentItemQuentity(item:IBasketItem)
      {
        const basket=this.getCurrentBasketValue();
        const finditemIndex=basket.items.findIndex(i=>i.id===item.id)
        if( basket.items[finditemIndex].count>1){
        basket.items[finditemIndex].count--;
        
        this.setBasket(basket);
        }
        else{
         this.removeItemFromBasket(item);
        }
      }
      removeItemFromBasket(item:IBasketItem)
      {
         const basket=this.getCurrentBasketValue();
           if(basket.items.some(i=>i.id==item.id))
           {
            basket.items.filter(i=>i.id!=item.id);
            if(basket.items.length>0)
            {
              this.setBasket(basket);
            }
            else{
              this.deleteBasket(basket);
            }
           }
      }
      deleteLocalBasket(id:string)
      {
        this.basketsource.next(null);
        this.basketTotalsource.next(null);
        localStorage.removeItem('basket_id');
      }
      deleteBasket(item:IBasket)
      {
         return this.http.delete(this.baseapiurl+'/Basket?id='+item.id).subscribe(()=>{
          this.basketsource.next(null);
          this.basketTotalsource.next(null);
          localStorage.removeItem('basket_id');
        },error=>{console.log(error)})
      }
      createOrder(order:IOrderToCreate)
      {
        return this.http.post(this.baseapiurl+"/Order",order);
      }
      getOrdersForUser()
      {
        return this.http.get(this.baseapiurl+"/Order")
      }
      getOrderDetails(id:string)
      {
        return this.http.get(this.baseapiurl+"/Order/"+id);
      }
    }