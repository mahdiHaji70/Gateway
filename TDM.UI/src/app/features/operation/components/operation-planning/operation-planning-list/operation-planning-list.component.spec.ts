import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationPlanningListComponent } from './operation-planning-list.component';

describe('OperationPlanningListComponent', () => {
  let component: OperationPlanningListComponent;
  let fixture: ComponentFixture<OperationPlanningListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OperationPlanningListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperationPlanningListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
