import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VesselDischargeListComponent } from './vessel-discharge-list.component';

describe('VesselDischargeListComponent', () => {
  let component: VesselDischargeListComponent;
  let fixture: ComponentFixture<VesselDischargeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [VesselDischargeListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VesselDischargeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
