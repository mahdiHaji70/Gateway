import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreTypeComponent } from './store-type.component';

describe('StoreTypeComponent', () => {
  let component: StoreTypeComponent;
  let fixture: ComponentFixture<StoreTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StoreTypeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoreTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
