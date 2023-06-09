import { Component } from '@angular/core';
import { Form, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable, first } from 'rxjs';
import { StdServiceService } from 'src/app/service/std-service.service';
import { User } from 'src/app/service/user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  RegisterForm:FormGroup;
  userdto:User;
error:string=null;
currentUser: User;

constructor(private acountserve:StdServiceService,private router:Router){}
  ngOnInit(): void {
    this.regForm();
    this.acountserve.user.subscribe(user => this.currentUser = user);

  }
  private regForm(){
    let email='';
    let password=' ';
    let name=' ';
    let city='';
    let streetAdress='';
    let postalCode='';
    let phoneNumber='';
    let role='Individual';
    let userName='';
    let DisPlayName='';

    
   /* if(this.EditMode)
    {
         const recipe=this.recipeService.getRecipe(this.index)
         recipeName=recipe.name;
         recipeDescrption=recipe.description;
         recipeImg=recipe.imgurl;
         
    };*/
      this.RegisterForm=new FormGroup({
       'email':new FormControl(email,Validators.required),
       'password':new FormControl(password,Validators.required),
       'name':new FormControl(name,Validators.required),
       'city':new FormControl(city,Validators.required),
       'phoneNumber':new FormControl(phoneNumber,Validators.required),
       'postalCode':new FormControl(postalCode,Validators.required),
       'streetAdress':new FormControl(streetAdress,Validators.required),
       'role':new FormControl(role,Validators.required),
       'userName':new FormControl(userName,Validators.required),
       'DisPlayName':new FormControl(DisPlayName,Validators.required)
      })

// *ngIf="currentUser&&currentUser.role=='Admin'"
   }

onSubmit(){
  console.log(this.RegisterForm.value);
  if(!this.currentUser)
  {
  let authobs:Observable<User>;
 authobs= this.acountserve.Register(this.RegisterForm.value)
 authobs.pipe(first())
 .subscribe({
   next: (res) => {
    localStorage.setItem('authToken', res.token);
     this.router.navigate(['/shopping']);},
   error: (error) => {
     this.error = error;
   },
 });}
 else{
  this.acountserve.RegisterUser(this.RegisterForm.value).subscribe((user)=>{
console.log(user)
this.router.navigate(['/shopping']);

  })
 }
}
onCancel(){
  this.router.navigate(['/shopping']);
}
}
