import { v4 as uuid } from 'uuid';
 export interface IBasket {
    id: string
    items: IBasketItem[]
    deliveryMethodId?: string
  clientSecret?: string
  paymentIntenId?: string
  shippingPrice?: number
  }
  
  export interface IBasketItem {
    id: string
  title: string
  price: number
  category: string
  count: number
  brand: string
  imageUrl: string
  }
  export class Basket implements IBasket{
    id=uuid();
    items: IBasketItem[]
  }
  export class IBasketTotals{
    shipping:number;
    subTotal:number;
    total:number;

  }