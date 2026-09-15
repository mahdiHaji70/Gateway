import { TestBed } from '@angular/core/testing';

import { VesselDischargeService } from './vessel-discharge.service';

describe('VesselDischargeService', () => {
  let service: VesselDischargeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VesselDischargeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
