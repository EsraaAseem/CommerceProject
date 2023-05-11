import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { StdDataServiceService } from 'src/app/service/std-dataservice.service';

@Component({
  selector: 'app-address-checkout',
  templateUrl: './address-checkout.component.html',
  styleUrls: ['./address-checkout.component.css']
})
export  class AddressCheckoutComponent implements OnInit{
  @Input() checkoutForm:FormGroup
  constructor(private service:StdDataServiceService){}
  ngOnInit(): void {
  }
saveUserAddress()
{
  this.service.updateUserAddress(this.checkoutForm.get('addressForm').value).subscribe((address)=>{
    this.checkoutForm.get('addressForm').reset(address);
    //console.log(address);
  },error=>{console.log(error)});
}
}
