import { Component, HostListener, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Category } from '../service/category.model';
import { StdDataServiceService } from '../service/std-dataservice.service';

@Component({
  selector: 'app-shopping',
  templateUrl: './shopping.component.html',
  styleUrls: ['./shopping.component.css']
})
export class ShoppingComponent implements OnInit{
  color='red';
  path=environment.baseurl;
  boximg='/Resources/CatImages/a1d2b57b-a1df-4e13-953f-19ffe40a01b7.jfif';
  categories:Category[]=[]
  @Input()ind:string;
  constructor(private router:Router,private route:ActivatedRoute,private service:StdDataServiceService){}
  ngOnInit(): void {
    this.service.getCategories().subscribe((success)=>{this.categories=success;});
   //this.getimg();
  // console.log(this.boximg)
  }
getitem(){this.router.navigate(['item'],{relativeTo:this.route})}

getimg(){
  if(this.categories.length>0)
  {
  setInterval(()=>{
let rand=Math.floor(Math.random()*this.categories.length);
this.boximg=this.categories[rand].imgCatPath
//this.boximg=this.service.getCatImgPath(this.categories[rand].imgCatPath);
console.log(this.boximg);
  },20000)
}
}
}
