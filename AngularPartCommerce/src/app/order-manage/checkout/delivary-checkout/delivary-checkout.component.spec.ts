import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DelivaryCheckoutComponent } from './delivary-checkout.component';

describe('DelivaryCheckoutComponent', () => {
  let component: DelivaryCheckoutComponent;
  let fixture: ComponentFixture<DelivaryCheckoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DelivaryCheckoutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DelivaryCheckoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
