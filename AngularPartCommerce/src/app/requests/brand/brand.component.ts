import { Component, OnInit } from '@angular/core';
import { Brand } from 'src/app/service/Brand.Model';
import { StdDataServiceService } from 'src/app/service/std-dataservice.service';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css']
})
export class BrandComponent implements OnInit{
  brands:Brand[]=[];
constructor(private service:StdDataServiceService){}
  ngOnInit(): void {
    this.service.getBrands().subscribe((success)=>{  this.brands=success;});
  }
}
