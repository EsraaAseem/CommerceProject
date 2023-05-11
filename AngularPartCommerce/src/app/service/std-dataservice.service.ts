import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, map, NotFoundError, observable, Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BrandRequest } from './brand-request.model';
import { Brand } from './Brand.Model';
import { CategoryRequest } from './category-request.model';
import { Category } from './category.model';
import { ProductRequest } from './product-request.model';
import { Product } from './product.model';
import { ShoppingCart } from './shoppingCart.model';
import { ShoppingCartRequest } from './shoppingCartRequest';
import { IAddress } from './IAddress.Model';
import { IDelievery } from './IDelievery.model';

@Injectable({
  providedIn: 'root'
})
export class StdDataServiceService {
      category:Category[]=[];
      editStd:Category;
      basket=0;
      shipping=0;
    /*  setshippingprice(delieveryMethod:)
      {
        this.shipping=
      }*/
  baseapiurl:string=environment.baseurl;
  private basketSource=new BehaviorSubject<ShoppingCart>(null);
  basket$=this.basketSource.asObservable();
    constructor(private http:HttpClient,private router:Router) {
     }
    
  getCategories():Observable<Category[]>{
     return this.http.get<Category[]>(this.baseapiurl+'/Category');  
  }
  addCategory(student:CategoryRequest):Observable<CategoryRequest>{
    return this.http.post<CategoryRequest>(this.baseapiurl+'/Category/Add',student)
   .pipe(
      map(({name,disorder,imgCatPath}) => {
        let std: CategoryRequest = {
          name:name,
          disorder: disorder,
         imgCatPath:imgCatPath
        }
        return std;
      })
    );  
  }
  uploadCatImg(file:File):Observable<any>{
    const formDate=new FormData();
    formDate.append("profimgfile",file);
    return this.http.post(this.baseapiurl+'/Category/upload-img',formDate,{responseType:'text'})
    }
    deleteCatImg(idimg:string):Observable<Category>{
      return this.http.delete<Category>(this.baseapiurl+'/Category/'+idimg+'/upload-img')
    }
    getCatImgPath(relativepath:string){
     return `${this.baseapiurl}${relativepath}`;
    }
    getCategory(stdId:string):Observable<Category>{
      return this.http.get<Category>(this.baseapiurl+'/Category/'+stdId)
   }
    updateCategory(id:string,category:CategoryRequest):Observable<CategoryRequest>{
  
      return this.http.post<CategoryRequest>(this.baseapiurl+'/Category/'+id,category)
     .pipe(
      map(({name,disorder,imgCatPath}) => {
        let std: CategoryRequest = {
          name:name,
          disorder: disorder,
         imgCatPath:imgCatPath
        }
        return std;
      })
      );  
    }
      getProducts(categoryId?:string,brandId?:string):Observable<Product[]> 
      {
        let params=new HttpParams();
      if(categoryId)
      {
        params=params.append('categoryId',categoryId)
      }
      if(brandId)
      {
        params=params.append('brandId',brandId)
      }
        return this.http.get<Product[]>(this.baseapiurl+'/Product/filter',{observe:'response',params})
        .pipe(map(res=>{return res.body;}));
      }
    /*  getAllProducts(catId?:string):Observable<Product[]> {
      return this.http.get<Product[]>(this.baseapiurl+'/Product/filter',catId);
      }*/
   getProduct(proId:string):Observable<Product>{
    return this.http.get<Product>(this.baseapiurl+'/Product/'+proId)
 }
    addProduct(product:ProductRequest):Observable<ProductRequest>{
      return this.http.post<ProductRequest>(this.baseapiurl+'/Product/Add',product)
     .pipe(
        map(({title,description,price,listPrice,imageUrl,categoryId,brandId}) => {
          let std: ProductRequest = {
            title:title,
            description:description,
            price:price,
            listPrice:listPrice,
            imageUrl:imageUrl,
            categoryId:categoryId,
            brandId:brandId
          }
          return std;
        })
      );  
    }

    updateProduct(id:string,product:ProductRequest):Observable<ProductRequest>{
  
      return this.http.post<ProductRequest>(this.baseapiurl+'/Product/'+id,product)
     .pipe(
      map(({title,description,price,listPrice,imageUrl,categoryId,brandId}) => {
        let std: ProductRequest = {
          title:title,
          description:description,
          price:price,
          listPrice:listPrice,
          imageUrl:imageUrl,
          categoryId:categoryId,
          brandId:brandId
        }
        return std;
      })
      );  
    }

    uploadProImg(file:File):Observable<any>{
      const formDate=new FormData();
      formDate.append("profimgfile",file);
      return this.http.post(this.baseapiurl+'/Product/upload-img',formDate,{responseType:'text'})
      }
      deleteProImg(idimg:string):Observable<Category>{
        return this.http.delete<Category>(this.baseapiurl+'/Product/'+idimg+'/upload-img')
      }
      getProImgPath(relativepath:string){
       return `${this.baseapiurl}${relativepath}`;
      }

      getBrands():Observable<Brand[]>{
        return this.http.get<Brand[]>(this.baseapiurl+'/Brand');  
     }
     getBrand(brandId:string):Observable<Brand>{
      return this.http.get<Brand>(this.baseapiurl+'/Brand/'+brandId)
   }
      addBrand(product:BrandRequest):Observable<BrandRequest>{
        return this.http.post<BrandRequest>(this.baseapiurl+'/Brand/Add',product)
       .pipe(
          map(({name}) => {
            let std: BrandRequest = {
              name:name
            }
            return std;
          })
        );  
      }
  
      updateBrand(id:string,product:BrandRequest):Observable<BrandRequest>{
    
        return this.http.post<BrandRequest>(this.baseapiurl+'/Brand/'+id,product)
       .pipe(
        map(({name}) => {
          let std: BrandRequest = {
            name:name
          }
          return std;
        })
        );  
      }
    AddShopping(cart:ShoppingCartRequest ):Observable<ShoppingCartRequest>{
      return this.http.post<ShoppingCartRequest>(this.baseapiurl+'/Shopping',cart)
      .pipe(
         map(({productId,applicationUserId,count,price}) => {
           let shopping: ShoppingCartRequest = {
            productId:productId,
            applicationUserId:applicationUserId,
            count:count,
            price:price
           }
           return shopping;
         })
       );  
    }

    IncreaseShopping(cart:ShoppingCartRequest ):Observable<ShoppingCartRequest>{
      return this.http.post<ShoppingCartRequest>(this.baseapiurl+'/Shopping/increase',cart)
      .pipe(
         map(({productId,applicationUserId,count,price}) => {
           let shopping: ShoppingCartRequest = {
            productId:productId,
            applicationUserId:applicationUserId,
            count:count,
            price:price
           }
           return shopping;
         })
       );  
    }
    DecreaseShopping(cart:ShoppingCartRequest ):Observable<ShoppingCartRequest>{
      return this.http.post<ShoppingCartRequest>(this.baseapiurl+'/Shopping/decrase',cart)
      .pipe(
         map(({productId,applicationUserId,count,price}) => {
           let shopping: ShoppingCartRequest = {
            productId:productId,
            applicationUserId:applicationUserId,
            count:count,
            price:price
           }
           return shopping;
         })
       );  
    }


    getCarts():Observable<ShoppingCart[]>{
      return this.http.get<ShoppingCart[]>(this.baseapiurl+'/Shopping')
      /*.pipe(map((bas:ShoppingCart)=>{
        this.basketSource.next(bas);
      }));*/
    }
    gettotalprice()
    {
      /*var prac=0;
      this.getCarts().subscribe((res)=>{return this.basket=res});*/
      /*for(let bre of this.basket)
      {
        prac+=bre.count*bre.product.price;
      }
      return prac;*/
    }
    getUserAddress():Observable<IAddress>{
      return this.http.get<IAddress>(this.baseapiurl+'/Account/getAddressUsers');
    }
    updateUserAddress(address:IAddress):Observable<IAddress>{
      return this.http.post<IAddress>(this.baseapiurl+'/Account/updateAddressUsers',address);
    }

    getDeliveryMethods():Observable<IDelievery[]>{
      return this.http.get<IDelievery[]>(this.baseapiurl+'/Order/getDelievery').pipe(map((dm:IDelievery[])=>{
        return dm.sort((a,b)=>b.price-a.price);
      }));
    }
}
