import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WinPatchConfigClientComponent } from './win-patch-config-client.component';

describe('WinPatchConfigClientComponent', () => {
  let component: WinPatchConfigClientComponent;
  let fixture: ComponentFixture<WinPatchConfigClientComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WinPatchConfigClientComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WinPatchConfigClientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
