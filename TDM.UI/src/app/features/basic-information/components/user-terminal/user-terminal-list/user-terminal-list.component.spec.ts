import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserTerminalListComponent } from './user-terminal-list.component';

describe('UserTerminalListComponent', () => {
  let component: UserTerminalListComponent;
  let fixture: ComponentFixture<UserTerminalListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UserTerminalListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserTerminalListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
