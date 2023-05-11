import { Component } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Brand } from 'src/app/service/Brand.Model';
import { StdDataServiceService } from 'src/app/service/std-dataservice.service';
import { StdServiceService } from 'src/app/service/std-service.service';
import { User } from 'src/app/service/user.model';

@Component({
  selector: 'app-edit-brand',
  templateUrl: './edit-brand.component.html',
  styleUrls: ['./edit-brand.component.css']
})
export class EditBrandComponent {
  EditMode=false;
  index:string;
  currentUser: User;
  loginerror:string=null;
   show:boolean=true;
   error: any;
   brand:Brand={
    id:'',
    name:'',
  
  }
   constructor(private service:StdDataServiceService,private route:ActivatedRoute,private router:Router,private stservice:StdServiceService){}
   ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.index=params['id'];
      this.EditMode=params['id']!=null;
     if(this.index)
      {
         this.service.getBrand(this.index).subscribe((success)=>{
          this.brand=success;
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
  
          this.service.updateBrand(this.index,this.brand)
          .subscribe(() => {
           console.log('brand updated successfully');
           this.router.navigate(['/brand']);

          })
          this.EditMode=true;
        }
        else{
        this.service.addBrand(this.brand)
        .subscribe(() => {
         console.log('brand added successfully');
         this.router.navigate(['/brand']);
        })
        this.EditMode=false;
        }
      }
    else{
      this.EditMode=false;
      this.loginerror="You must Login"
    }
    this.EditMode=false;
    }
  
    onDelete(){
      /*this.service.deleteCatImg(this.index).subscribe();
      this.EditMode=false;*/
    }
    onCancel(){
      this.router.navigate(['/brand']);
    }
    onClose(){
      this.loginerror='';
      return this.show=!this.show;
    }
}
