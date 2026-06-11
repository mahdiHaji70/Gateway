import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeclarationContainerInfoComponent } from './declaration-container-info.component';

describe('DeclarationContainerInfoComponent', () => {
  let component: DeclarationContainerInfoComponent;
  let fixture: ComponentFixture<DeclarationContainerInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeclarationContainerInfoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeclarationContainerInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
