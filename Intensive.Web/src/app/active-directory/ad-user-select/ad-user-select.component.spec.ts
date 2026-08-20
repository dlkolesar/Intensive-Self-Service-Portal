import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdUserSelectComponent } from './ad-user-select.component';

describe('AdUserSelectComponent', () => {
  let component: AdUserSelectComponent;
  let fixture: ComponentFixture<AdUserSelectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdUserSelectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdUserSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
