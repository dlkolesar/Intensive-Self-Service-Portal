import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PatchingReportComponent } from './patching-report.component';

describe('PatchingReportComponent', () => {
  let component: PatchingReportComponent;
  let fixture: ComponentFixture<PatchingReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PatchingReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PatchingReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
