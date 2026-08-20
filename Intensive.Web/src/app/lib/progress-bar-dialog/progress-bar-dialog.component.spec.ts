import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProgressBarDialogComponent } from './progress-bar-dialog.component';

describe('ProgressBarDialogComponent', () => {
  let component: ProgressBarDialogComponent;
  let fixture: ComponentFixture<ProgressBarDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProgressBarDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProgressBarDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
