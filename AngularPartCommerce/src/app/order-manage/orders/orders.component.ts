import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/service/basket.service';
import { IOrder } from 'src/app/service/order';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit{
  orders:IOrder[]=[];
  constructor(private basketServer:BasketService){

  }
  ngOnInit(): void {
    this.getOrders();
 }
getOrders()
{
  this.basketServer.getOrdersForUser().subscribe((res:IOrder[])=>{
    this.orders=res;
    console.log(res);
  },error=>{console.log(error)})
}
}
