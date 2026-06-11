import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlaceTypeListComponent } from './place-type-list.component';

describe('PlaceTypeListComponent', () => {
  let component: PlaceTypeListComponent;
  let fixture: ComponentFixture<PlaceTypeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PlaceTypeListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PlaceTypeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
