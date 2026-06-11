import { TestBed } from '@angular/core/testing';

import { OperationDetailService } from './operation-detail.service';

describe('OperationDetailService', () => {
  let service: OperationDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OperationDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
