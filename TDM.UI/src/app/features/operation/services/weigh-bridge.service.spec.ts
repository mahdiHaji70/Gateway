import { TestBed } from '@angular/core/testing';

import { WeighBridgeService } from './weigh-bridge.service';

describe('WeighBridgeService', () => {
  let service: WeighBridgeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WeighBridgeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
