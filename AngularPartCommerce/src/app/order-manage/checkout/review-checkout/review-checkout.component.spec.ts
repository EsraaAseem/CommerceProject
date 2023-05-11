import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReviewCheckoutComponent } from './review-checkout.component';

describe('ReviewCheckoutComponent', () => {
  let component: ReviewCheckoutComponent;
  let fixture: ComponentFixture<ReviewCheckoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReviewCheckoutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReviewCheckoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
