import { TestBed } from '@angular/core/testing';

import { DeclarationContainerInfoService } from './declaration-container-info.service';

describe('DeclarationContainerInfoService', () => {
  let service: DeclarationContainerInfoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DeclarationContainerInfoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
