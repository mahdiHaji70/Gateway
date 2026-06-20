import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreTypeListComponent } from './store-type-list.component';

describe('StoreTypeListComponent', () => {
  let component: StoreTypeListComponent;
  let fixture: ComponentFixture<StoreTypeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StoreTypeListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoreTypeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
