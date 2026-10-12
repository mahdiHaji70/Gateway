import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WarehouseAllocationComponent } from './warehouse-allocation.component';

describe('WarehouseAllocationComponent', () => {
  let component: WarehouseAllocationComponent;
  let fixture: ComponentFixture<WarehouseAllocationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WarehouseAllocationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WarehouseAllocationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
