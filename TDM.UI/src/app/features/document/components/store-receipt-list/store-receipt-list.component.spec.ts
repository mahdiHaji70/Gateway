import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreReceiptListComponent } from './store-receipt-list.component';

describe('StoreReceiptListComponent', () => {
  let component: StoreReceiptListComponent;
  let fixture: ComponentFixture<StoreReceiptListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StoreReceiptListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoreReceiptListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
