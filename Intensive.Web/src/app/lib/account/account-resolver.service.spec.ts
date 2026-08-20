import { TestBed, inject } from '@angular/core/testing';

import { AccountResolverService } from './account-resolver.service';

describe('AccountResolverService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AccountResolverService]
    });
  });

  it('should be created', inject([AccountResolverService], (service: AccountResolverService) => {
    expect(service).toBeTruthy();
  }));
});
