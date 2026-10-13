import { TestBed } from '@angular/core/testing';

import { LoadingPermitService } from './loading-permit.service';

describe('LoadingPermitService', () => {
  let service: LoadingPermitService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoadingPermitService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
