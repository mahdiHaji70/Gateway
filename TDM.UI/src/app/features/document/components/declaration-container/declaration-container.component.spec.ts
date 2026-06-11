import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeclarationContainerComponent } from './declaration-container.component';

describe('DeclarationContainerComponent', () => {
  let component: DeclarationContainerComponent;
  let fixture: ComponentFixture<DeclarationContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeclarationContainerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeclarationContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
