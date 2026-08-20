import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdObjectTreeComponent } from './ad-object-tree.component';

describe('AdObjectTreeComponent', () => {
  let component: AdObjectTreeComponent;
  let fixture: ComponentFixture<AdObjectTreeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdObjectTreeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdObjectTreeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
