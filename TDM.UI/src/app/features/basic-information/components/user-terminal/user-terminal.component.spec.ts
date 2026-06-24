import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserTerminalComponent } from './user-terminal.component';

describe('UserTerminalComponent', () => {
  let component: UserTerminalComponent;
  let fixture: ComponentFixture<UserTerminalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UserTerminalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserTerminalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
