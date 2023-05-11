import { Component } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Brand } from 'src/app/service/Brand.Model';
import { Category } from 'src/app/service/category.model';
import { Product } from 'src/app/service/product.model';
import { StdDataServiceService } from 'src/app/service/std-dataservice.service';
import { StdServiceService } from 'src/app/service/std-service.service';
import { User } from 'src/app/service/user.model';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent {
  EditMode=false;
  index:string;
  currentUser: User;
  loginerror:string=null;
   show:boolean=true;
   error: any;
   imagephoto:any;
   categories:Category[]=[];
   brands:Brand[]=[];
   profileimg='assets/images/Shopping-Logo.png';
   product:Product={
    id:'',
    title:'',
    description:'',
    imageUrl:'',
    price:0,
    listPrice:0,
    category:{
      id:'',
      name:'',
      disorder:'',
      imgCatPath:''
    },
    brand:{
      id:'',
      name:''
    },
    categoryId:'',
    brandId:''
  }
   constructor(private service:StdDataServiceService,private route:ActivatedRoute,private router:Router,private stservice:StdServiceService){}
   ngOnInit(): void {
    this.service.getCategories().subscribe((success)=>{  this.categories=success;});
    this.service.getBrands().subscribe((success)=>{  this.brands=success;});

    console.log(this.imagephoto);
    this.route.params.subscribe((params:Params)=>{
      this.index=params['id'];
      this.EditMode=params['id']!=null;
     if(this.index)
      {
         this.service.getProduct(this.index).subscribe((success)=>{
          this.product=success;
          if(success.imageUrl!=null)
          {
            console.log(success.imageUrl)
         // this.setimg();
         this.profileimg=this.service.getProImgPath(success.imageUrl);
         console.log(this.profileimg)

          }
         // else{this.profileimg='/assets/category.jpg';}
          //console.log(success);
         })
      }
       })
       this.stservice.user.subscribe(user => this.currentUser = user);
     }
  
 
  
  onSubmit(){
    this.show=true;
    if(this.currentUser)
    {
      if(this.EditMode==true)
      {

        this.service.updateProduct(this.index,this.product)
        .subscribe(() => {
         console.log('product updated successfully');
        this.router.navigate(['/product']);})
        this.EditMode=true;
        this.setimg();
      }
      else{
      this.service.addProduct(this.product)
      .subscribe(() => {
       console.log('product added successfully');
       console.log(this.product.imageUrl);
      this.router.navigate(['/product']);})
      this.EditMode=false;
      }
    }
  else{
    this.EditMode=false;
    this.loginerror="You must Login"
  }
  this.EditMode=false;
  }
  uploadImage(itme:any){
    if(this.EditMode)
    {
      this.service.deleteProImg(this.index).subscribe();
    }
const file:File=itme.target.files[0];
this.service.uploadProImg(file).subscribe((success)=>{

  this.product.imageUrl=success,
//  console.log(this.product.imgUrl)
  this.setimg()
  //this.student.imgUrl=success
})
  }
 




  setimg(){
  if(this.product.imageUrl !=null||this.product.imageUrl !='')
    {
      this.profileimg=this.service.getProImgPath(this.product.imageUrl);
    }
    else{
      console.log(this.product.imageUrl);
      this.profileimg='assets/images/Shopping-Logo.png';

    }

  }
  onDelete(){
    this.service.deleteProImg(this.index).subscribe();
   /* this.service.deleteStudent(this.index)
    .subscribe(() => {
     console.log('Student deleted successfully');
    this.router.navigate(['/Student']);})*/
    this.EditMode=false;
  }
  onCancel(){
    this.router.navigate(['/product']);
  }
  onClose(){
    this.loginerror='';
    return this.show=!this.show;
  }
}
