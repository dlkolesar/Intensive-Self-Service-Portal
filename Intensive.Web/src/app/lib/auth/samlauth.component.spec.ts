import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SAMLAuthComponent } from './samlauth.component';

describe('SAMLAuthComponent', () => {
  let component: SAMLAuthComponent;
  let fixture: ComponentFixture<SAMLAuthComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SAMLAuthComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SAMLAuthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
