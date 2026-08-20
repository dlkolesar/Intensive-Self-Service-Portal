import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WinPatchDashboardComponent } from './win-patch-dashboard.component';

describe('WinPatchDashboardComponent', () => {
  let component: WinPatchDashboardComponent;
  let fixture: ComponentFixture<WinPatchDashboardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WinPatchDashboardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WinPatchDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
