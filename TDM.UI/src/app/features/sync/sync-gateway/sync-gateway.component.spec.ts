import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SyncGatewayComponent } from './sync-gateway.component';

describe('SyncGatewayComponent', () => {
  let component: SyncGatewayComponent;
  let fixture: ComponentFixture<SyncGatewayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SyncGatewayComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SyncGatewayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
