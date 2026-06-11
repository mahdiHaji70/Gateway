import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeighBridgeListComponent } from './weigh-bridge-list.component';

describe('WeighBridgeListComponent', () => {
  let component: WeighBridgeListComponent;
  let fixture: ComponentFixture<WeighBridgeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WeighBridgeListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeighBridgeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
