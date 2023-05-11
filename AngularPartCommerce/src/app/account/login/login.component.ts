import { Component, OnInit } from '@angular/core';
import { Form, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription, Observable, first } from 'rxjs';
import { BasketService } from 'src/app/service/basket.service';
import { StdServiceService } from 'src/app/service/std-service.service';
import { User } from 'src/app/service/user.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  error:string=null;
  currentuser:Subscription;
   authobsuser:Observable<User>;

 // loginform:FormGroup
  constructor(private basketService:BasketService,private stdservice:StdServiceService,private router:Router){}

  ngOnInit(): void {
    //this.privateform();
   // console.log(localStorage.getItem("token"));
  // this.currentuser=this.stdservice.user.subscribe();
   
  }
  onSubmitForm(sub:NgForm){
    if(!sub.valid)
    {
      return;
    }
    let authobs:Observable<User>;
    const email=sub.value.email;
    const password=sub.value.password;
   authobs= this.stdservice.Login(email,password);
    
    authobs.pipe(first())
    .subscribe({
      next: (res) => { 
        localStorage.setItem('authToken', res.token);
        this.basketService.checkId(res.userName).subscribe((r)=>{
          if(r==true)
          {
          localStorage.setItem('basket_id',res.userName);
          this.basketService.getBasket(res.userName)
         .subscribe(()=>{
        // console.log("current basket")

    },error=>{console.log(error)})
          }
        },error=>{console.log("there no basket")});

        this.router.navigate(['/shopping']);},
      error: (error) => {
        this.error = error;
      },
     
     });
  }
}
