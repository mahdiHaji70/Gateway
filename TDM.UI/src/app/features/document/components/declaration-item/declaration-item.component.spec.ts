import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeclarationItemComponent } from './declaration-item.component';

describe('DeclarationItemComponent', () => {
  let component: DeclarationItemComponent;
  let fixture: ComponentFixture<DeclarationItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeclarationItemComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeclarationItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
