import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApiPrimerComponent } from './api-primer.component';

describe('ApiPrimerComponent', () => {
  let component: ApiPrimerComponent;
  let fixture: ComponentFixture<ApiPrimerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApiPrimerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApiPrimerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
