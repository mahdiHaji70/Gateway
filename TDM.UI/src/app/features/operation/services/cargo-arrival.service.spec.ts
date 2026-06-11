import { TestBed } from '@angular/core/testing';

import { CargoArrivalService } from './cargo-arrival.service';

describe('CargoArrivalService', () => {
  let service: CargoArrivalService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CargoArrivalService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
