import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/service/category.model';
import { StdDataServiceService } from 'src/app/service/std-dataservice.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit{
  categories:Category[]=[];
constructor(private service:StdDataServiceService){}
  ngOnInit(): void {
    this.service.getCategories().subscribe((success)=>{  this.categories=success;});

  }

}
