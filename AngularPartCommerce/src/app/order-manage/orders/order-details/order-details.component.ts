import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from 'src/app/service/basket.service';
import { IOrder } from 'src/app/service/order';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit{
  order:IOrder;
  constructor(private route:ActivatedRoute,private baskerservice:BasketService,/*private breadcrumb:BreadcrumbService*/){}
  ngOnInit(): void {
    this.baskerservice.getOrderDetails(this.route.snapshot.paramMap.get('id')).subscribe((res:IOrder)=>{
      this.order=res;
      console.log(res)
    },error=>{console.log(error)});
  }

}
