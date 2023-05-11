import { Brand } from "./Brand.Model";
import { Category } from "./category.model";

export interface Product{
    id:string;
    title:string;
    description:string;
    price:number;
    listPrice:number;
    imageUrl:string;
    categoryId:string;
    category:Category;
    brandId:string;
    brand:Brand;
}