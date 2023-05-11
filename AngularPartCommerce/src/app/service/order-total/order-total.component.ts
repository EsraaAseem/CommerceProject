import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IBasketTotals } from 'src/app/service/basket.model';
import { BasketService } from 'src/app/service/basket.service';

@Component({
  selector: 'app-order-total',
  templateUrl: './order-total.component.html',
  styleUrls: ['./order-total.component.css']
})
export class OrderTotalComponent implements OnInit{
  basketTotal$:Observable<IBasketTotals>;
  constructor(private basketservice:BasketService){}
  ngOnInit(): void {
    this.basketTotal$=this.basketservice.basketTotal$;
  }

}
