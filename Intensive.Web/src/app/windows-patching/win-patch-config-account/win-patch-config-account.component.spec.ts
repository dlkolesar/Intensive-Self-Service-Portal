import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WinPatchConfigAccountComponent } from './win-patch-config-account.component';

describe('WinPatchConfigAccountComponent', () => {
  let component: WinPatchConfigAccountComponent;
  let fixture: ComponentFixture<WinPatchConfigAccountComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WinPatchConfigAccountComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WinPatchConfigAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
