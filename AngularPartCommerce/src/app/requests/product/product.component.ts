import { Component } from '@angular/core';
import { Product } from 'src/app/service/product.model';
import { StdDataServiceService } from 'src/app/service/std-dataservice.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent {
  products:Product[]=[];
  constructor(private service:StdDataServiceService){}
    ngOnInit(): void {
      this.service.getProducts().subscribe((success)=>{  this.products=success;});
  
    }
    
}
