import { TestBed, inject } from '@angular/core/testing';

import { AuditingService } from './auditing.service';

describe('AuditingService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AuditingService]
    });
  });

  it('should be created', inject([AuditingService], (service: AuditingService) => {
    expect(service).toBeTruthy();
  }));
});
