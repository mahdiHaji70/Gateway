import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreReceiptIssueComponent } from './store-receipt-issue.component';

describe('StoreReceiptIssueComponent', () => {
  let component: StoreReceiptIssueComponent;
  let fixture: ComponentFixture<StoreReceiptIssueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StoreReceiptIssueComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoreReceiptIssueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
