import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangePackageComponent } from './change-package.component';

describe('ChangePackageComponent', () => {
  let component: ChangePackageComponent;
  let fixture: ComponentFixture<ChangePackageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ChangePackageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChangePackageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
