import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeighBridgeComponent } from './weigh-bridge.component';

describe('WeighBridgeComponent', () => {
  let component: WeighBridgeComponent;
  let fixture: ComponentFixture<WeighBridgeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WeighBridgeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeighBridgeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
