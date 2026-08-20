import { TestBed, inject } from '@angular/core/testing';

import { ActiveDirectoryService } from './active-directory.service';

describe('ActiveDirectoryService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ActiveDirectoryService]
    });
  });

  it('should be created', inject([ActiveDirectoryService], (service: ActiveDirectoryService) => {
    expect(service).toBeTruthy();
  }));
});
