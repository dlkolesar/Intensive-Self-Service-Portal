import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketGeneratorProgressComponent } from './ticket-generator-progress.component';

describe('TicketGeneratorProgressComponent', () => {
  let component: TicketGeneratorProgressComponent;
  let fixture: ComponentFixture<TicketGeneratorProgressComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TicketGeneratorProgressComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TicketGeneratorProgressComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
