import { TestBed, async, inject } from '@angular/core/testing';

import { PatchingAdminGuard } from './patching-admin.guard';

describe('PatchingAdminGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PatchingAdminGuard]
    });
  });

  it('should ...', inject([PatchingAdminGuard], (guard: PatchingAdminGuard) => {
    expect(guard).toBeTruthy();
  }));
});
