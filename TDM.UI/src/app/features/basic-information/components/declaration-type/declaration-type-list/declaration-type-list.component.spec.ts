import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeclarationTypeListComponent } from './declaration-type-list.component';

describe('DeclarationTypeListComponent', () => {
  let component: DeclarationTypeListComponent;
  let fixture: ComponentFixture<DeclarationTypeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeclarationTypeListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeclarationTypeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
