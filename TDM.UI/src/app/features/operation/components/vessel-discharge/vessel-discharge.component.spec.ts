import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VesselDischargeComponent } from './vessel-discharge.component';

describe('VesselDischargeComponent', () => {
  let component: VesselDischargeComponent;
  let fixture: ComponentFixture<VesselDischargeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [VesselDischargeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VesselDischargeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
