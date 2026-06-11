import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GateOutListComponent } from './gate-out-list.component';

describe('GateOutListComponent', () => {
  let component: GateOutListComponent;
  let fixture: ComponentFixture<GateOutListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GateOutListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GateOutListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
