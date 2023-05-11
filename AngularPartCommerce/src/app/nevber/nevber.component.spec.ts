import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NevberComponent } from './nevber.component';

describe('NevberComponent', () => {
  let component: NevberComponent;
  let fixture: ComponentFixture<NevberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NevberComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NevberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
