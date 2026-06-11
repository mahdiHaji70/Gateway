import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreReceiptRequestComponent } from './store-receipt-request.component';

describe('StoreReceiptRequestComponent', () => {
  let component: StoreReceiptRequestComponent;
  let fixture: ComponentFixture<StoreReceiptRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StoreReceiptRequestComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoreReceiptRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
