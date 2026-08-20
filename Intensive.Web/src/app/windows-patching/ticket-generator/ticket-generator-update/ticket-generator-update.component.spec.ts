import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketGeneratorUpdateComponent } from './ticket-generator-update.component';

describe('TicketGeneratorUpdateComponent', () => {
  let component: TicketGeneratorUpdateComponent;
  let fixture: ComponentFixture<TicketGeneratorUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TicketGeneratorUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TicketGeneratorUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
