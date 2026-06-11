import { TestBed } from '@angular/core/testing';

import { StoreReceiptRequestService } from './store-receipt-request.service';

describe('StoreReceiptRequestService', () => {
  let service: StoreReceiptRequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StoreReceiptRequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
