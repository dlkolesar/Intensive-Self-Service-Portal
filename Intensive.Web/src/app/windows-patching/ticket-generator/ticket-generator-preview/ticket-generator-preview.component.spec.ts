import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketGeneratorPreviewComponent } from './ticket-generator-preview.component';

describe('TicketGeneratorPreviewComponent', () => {
  let component: TicketGeneratorPreviewComponent;
  let fixture: ComponentFixture<TicketGeneratorPreviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TicketGeneratorPreviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TicketGeneratorPreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
