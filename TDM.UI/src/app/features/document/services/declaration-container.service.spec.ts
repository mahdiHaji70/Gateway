import { TestBed } from '@angular/core/testing';

import { DeclarationContainerService } from './declaration-container.service';

describe('DeclarationContainerService', () => {
  let service: DeclarationContainerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DeclarationContainerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
