import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GateInListComponent } from './gate-in-list.component';

describe('GateInListComponent', () => {
  let component: GateInListComponent;
  let fixture: ComponentFixture<GateInListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GateInListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GateInListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
