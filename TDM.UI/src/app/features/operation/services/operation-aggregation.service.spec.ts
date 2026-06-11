import { TestBed } from '@angular/core/testing';

import { OperationAggregationService } from './operation-aggregation.service';

describe('OperationAggregationService', () => {
  let service: OperationAggregationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OperationAggregationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
