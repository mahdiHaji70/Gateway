import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoadingPermitComponent } from './loading-permit.component';

describe('LoadingPermitComponent', () => {
  let component: LoadingPermitComponent;
  let fixture: ComponentFixture<LoadingPermitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LoadingPermitComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoadingPermitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
