import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ObjectCheckListComponent } from './object-check-list.component';

describe('ObjectCheckListComponent', () => {
  let component: ObjectCheckListComponent;
  let fixture: ComponentFixture<ObjectCheckListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ObjectCheckListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ObjectCheckListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
