import { TestBed } from '@angular/core/testing';

import { NevberService } from './nevber.service';

describe('NevberService', () => {
  let service: NevberService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NevberService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
