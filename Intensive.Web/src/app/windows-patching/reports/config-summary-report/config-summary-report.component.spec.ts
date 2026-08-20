import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigSummaryReportComponent } from './config-summary-report.component';

describe('ConfigSummaryReportComponent', () => {
  let component: ConfigSummaryReportComponent;
  let fixture: ComponentFixture<ConfigSummaryReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfigSummaryReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfigSummaryReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
