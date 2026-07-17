import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreReceiptIssueRequestComponent } from './store-receipt-issue-request.component';

describe('StoreReceiptIssueRequestComponent', () => {
  let component: StoreReceiptIssueRequestComponent;
  let fixture: ComponentFixture<StoreReceiptIssueRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StoreReceiptIssueRequestComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoreReceiptIssueRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
