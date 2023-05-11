import { IAddress } from "./IAddress.Model"

export interface IOrderToCreate {
    basketId: string
    delivaryMethodId: string
    shippingToAddress: IAddress
  }
  export interface IOrder {
    id: string
    buyerEmail: string
    orderDate: string
    shippToAddress: IAddress
    delivaryMethod: string
    shippingPrice: number
    orderItems: IOrderItem[]
    subTotal: number
    total: number
    status: string
  }
  
  export interface IOrderItem {
    id: string
    title: string
    imageUrl: string
    price: number
    quentity: number
  }