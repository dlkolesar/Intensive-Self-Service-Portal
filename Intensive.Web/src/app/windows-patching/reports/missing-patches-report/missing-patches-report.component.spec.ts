import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MissingPatchesReportComponent } from './missing-patches-report.component';

describe('MissingPatchesReportComponent', () => {
  let component: MissingPatchesReportComponent;
  let fixture: ComponentFixture<MissingPatchesReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MissingPatchesReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MissingPatchesReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
