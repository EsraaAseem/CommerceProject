import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Category } from 'src/app/service/category.model';
import { StdDataServiceService } from 'src/app/service/std-dataservice.service';
import { StdServiceService } from 'src/app/service/std-service.service';
import { User } from 'src/app/service/user.model';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit{
  EditMode=false;
  index:string;
  currentUser: User;
  loginerror:string=null;
   show:boolean=true;
   error: any;
   imagephoto:any;
   profileimg='assets/images/Shopping-Logo.png';
   category:Category={
    id:'',
    name:'',
    disorder:'',
    imgCatPath:''
  }
   constructor(private service:StdDataServiceService,private route:ActivatedRoute,private router:Router,private stservice:StdServiceService){}
   ngOnInit(): void {
    console.log(this.imagephoto);
    this.route.params.subscribe((params:Params)=>{
      this.index=params['id'];
      this.EditMode=params['id']!=null;
     if(this.index)
      {
         this.service.getCategory(this.index).subscribe((success)=>{
          this.category=success;
          if(success.imgCatPath!=null)
          {
            console.log(success.imgCatPath)
         // this.setimg();
         this.profileimg=this.service.getCatImgPath(success.imgCatPath);
         console.log(this.profileimg)

          }
          else{
            this.profileimg='/assets/category.jpg';

          }
          console.log(success);
         })
            //   this.student=this.stdservice.editStd
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

        this.service.updateCategory(this.index,this.category)
        .subscribe(() => {
         console.log('Student updated successfully');
        this.router.navigate(['/category']);})
        this.EditMode=true;
        this.setimg();
      }
      else{
      this.service.addCategory(this.category)
      .subscribe(() => {
       console.log('Student added successfully');
      this.router.navigate(['/category']);})
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
      this.service.deleteCatImg(this.index).subscribe();
    }
const file:File=itme.target.files[0];
console.log(file);
this.service.uploadCatImg(file).subscribe((success)=>{

  this.category.imgCatPath=success,
  console.log(success)
  this.setimg()
  //this.student.imgUrl=success
})
  }

  setimg(){
   if(this.category.imgCatPath !=null||this.category.imgCatPath !='')
    {
      this.profileimg=this.service.getCatImgPath(this.category.imgCatPath);
    }
    else{
      console.log(this.category.imgCatPath);
      this.profileimg='assets/images/Shopping-Logo.png';

    }

  }
  onDelete(){
    this.service.deleteCatImg(this.index).subscribe();
   /* this.service.deleteStudent(this.index)
    .subscribe(() => {
     console.log('Student deleted successfully');
    this.router.navigate(['/Student']);})*/
    this.EditMode=false;
  }
  onCancel(){
    this.router.navigate(['/category']);
  }
  onClose(){
    this.loginerror='';
    return this.show=!this.show;
  }
}
