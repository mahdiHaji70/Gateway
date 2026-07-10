import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SendDischargeComponent } from './send-discharge.component';

describe('SendDischargeComponent', () => {
  let component: SendDischargeComponent;
  let fixture: ComponentFixture<SendDischargeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SendDischargeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SendDischargeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
