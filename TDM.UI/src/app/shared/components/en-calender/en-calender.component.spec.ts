import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnCalenderComponent } from './en-calender.component';

describe('EnCalenderComponent', () => {
  let component: EnCalenderComponent;
  let fixture: ComponentFixture<EnCalenderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EnCalenderComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EnCalenderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
