import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CargoTypeListComponent } from './cargo-type-list.component';

describe('CargoTypeListComponent', () => {
  let component: CargoTypeListComponent;
  let fixture: ComponentFixture<CargoTypeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CargoTypeListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CargoTypeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
