import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarineStoreReceiptIssueComponent } from './marine-store-receipt-issue.component';

describe('MarineStoreReceiptIssueComponent', () => {
  let component: MarineStoreReceiptIssueComponent;
  let fixture: ComponentFixture<MarineStoreReceiptIssueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MarineStoreReceiptIssueComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MarineStoreReceiptIssueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
