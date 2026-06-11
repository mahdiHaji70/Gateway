import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperationAggregationComponent } from './operation-aggregation.component';

describe('OperationAggregationComponent', () => {
  let component: OperationAggregationComponent;
  let fixture: ComponentFixture<OperationAggregationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OperationAggregationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperationAggregationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
