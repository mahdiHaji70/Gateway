import { TestBed } from '@angular/core/testing';

import { DeclarationItemService } from './declaration-item.service';

describe('DeclarationItemService', () => {
  let service: DeclarationItemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DeclarationItemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
