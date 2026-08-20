import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WinPatchConfigComponent } from './win-patch-config.component';

describe('WinPatchConfigComponent', () => {
  let component: WinPatchConfigComponent;
  let fixture: ComponentFixture<WinPatchConfigComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WinPatchConfigComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WinPatchConfigComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
