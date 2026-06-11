import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeclarationTypeComponent } from './declaration-type.component';

describe('DeclarationTypeComponent', () => {
  let component: DeclarationTypeComponent;
  let fixture: ComponentFixture<DeclarationTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeclarationTypeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeclarationTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
