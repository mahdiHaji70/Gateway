import { TestBed } from '@angular/core/testing';

import { OperationPlanningService } from './operation-planning.service';

describe('OperationPlanningService', () => {
  let service: OperationPlanningService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OperationPlanningService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
