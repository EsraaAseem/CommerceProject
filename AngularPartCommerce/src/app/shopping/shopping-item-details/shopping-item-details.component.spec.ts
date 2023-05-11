import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingItemDetailsComponent } from './shopping-item-details.component';

describe('ShoppingItemDetailsComponent', () => {
  let component: ShoppingItemDetailsComponent;
  let fixture: ComponentFixture<ShoppingItemDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoppingItemDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingItemDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
