import { Product } from "./product.model";

export interface ShoppingCart{
  productId:string,
  applicationUserId:string,
  count:number,
  price:number,
  applicationUser:string,
  product:Product
}