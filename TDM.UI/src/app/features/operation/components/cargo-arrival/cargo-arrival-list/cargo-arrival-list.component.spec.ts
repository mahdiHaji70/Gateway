import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CargoArrivalListComponent } from './cargo-arrival-list.component';

describe('CargoArrivalListComponent', () => {
  let component: CargoArrivalListComponent;
  let fixture: ComponentFixture<CargoArrivalListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CargoArrivalListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CargoArrivalListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
