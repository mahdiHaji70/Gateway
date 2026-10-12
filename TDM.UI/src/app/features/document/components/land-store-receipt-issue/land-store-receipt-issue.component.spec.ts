import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LandStoreReceiptIssueComponent } from './land-store-receipt-issue.component';

describe('LandStoreReceiptIssueComponent', () => {
  let component: LandStoreReceiptIssueComponent;
  let fixture: ComponentFixture<LandStoreReceiptIssueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LandStoreReceiptIssueComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LandStoreReceiptIssueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
