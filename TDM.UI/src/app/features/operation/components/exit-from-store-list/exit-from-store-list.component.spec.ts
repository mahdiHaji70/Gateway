import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExitFromStoreListComponent } from './exit-from-store-list.component';

describe('ExitFromStoreListComponent', () => {
  let component: ExitFromStoreListComponent;
  let fixture: ComponentFixture<ExitFromStoreListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExitFromStoreListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExitFromStoreListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
