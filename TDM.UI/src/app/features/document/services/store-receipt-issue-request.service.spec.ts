import { TestBed } from '@angular/core/testing';

import { StoreReceiptIssueRequestService } from './store-receipt-issue-request.service';

describe('StoreReceiptIssueRequestService', () => {
  let service: StoreReceiptIssueRequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StoreReceiptIssueRequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
