import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketGeneratorConfigComponent } from './ticket-generator-config.component';

describe('TicketGeneratorConfigComponent', () => {
  let component: TicketGeneratorConfigComponent;
  let fixture: ComponentFixture<TicketGeneratorConfigComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TicketGeneratorConfigComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TicketGeneratorConfigComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
