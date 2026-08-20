import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdMigrationOptionsDialogComponent } from './ad-migration-options-dialog.component';

describe('AdMigrationOptionsDialogComponent', () => {
  let component: AdMigrationOptionsDialogComponent;
  let fixture: ComponentFixture<AdMigrationOptionsDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdMigrationOptionsDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdMigrationOptionsDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
