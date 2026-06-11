import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationPlanningComponent } from './operation-planning.component';

describe('OperationPlanningComponent', () => {
  let component: OperationPlanningComponent;
  let fixture: ComponentFixture<OperationPlanningComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OperationPlanningComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperationPlanningComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
