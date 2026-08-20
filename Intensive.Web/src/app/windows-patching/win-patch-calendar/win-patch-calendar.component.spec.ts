import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WinPatchCalendarComponent } from './win-patch-calendar.component';

describe('WinPatchCalendarComponent', () => {
  let component: WinPatchCalendarComponent;
  let fixture: ComponentFixture<WinPatchCalendarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WinPatchCalendarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WinPatchCalendarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
