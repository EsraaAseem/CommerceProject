import { Brand } from "./Brand.Model";
import { Category } from "./category.model";

export interface ProductRequest{
    title:string;
    description:string;
    price:number;
    listPrice:number;
    imageUrl:string;
    categoryId:string;
    brandId:string;
}