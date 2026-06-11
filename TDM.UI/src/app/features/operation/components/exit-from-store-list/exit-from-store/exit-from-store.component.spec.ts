import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExitFromStoreComponent } from './exit-from-store.component';

describe('ExitFromStoreComponent', () => {
  let component: ExitFromStoreComponent;
  let fixture: ComponentFixture<ExitFromStoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExitFromStoreComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExitFromStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
