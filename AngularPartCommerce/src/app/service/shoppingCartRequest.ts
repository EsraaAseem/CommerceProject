import { Product } from "./product.model";

export interface ShoppingCartRequest{
  productId:string,
  applicationUserId:string,
  count:number,
  price:number,
}