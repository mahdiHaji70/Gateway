import { TestBed } from '@angular/core/testing';

import { StoreReceiptIssueService } from './store-receipt.service';

describe('StoreReceiptIssueService', () => {
  let service: StoreReceiptIssueService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StoreReceiptIssueService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
