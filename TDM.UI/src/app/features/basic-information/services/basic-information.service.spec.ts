import { TestBed } from '@angular/core/testing';

import { BasicInformationService } from './basic-information.service';

describe('TrafficService', () => {
  let service: BasicInformationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BasicInformationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
