import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WagonListComponent } from './wagon-list.component';

describe('WagonListComponent', () => {
  let component: WagonListComponent;
  let fixture: ComponentFixture<WagonListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WagonListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WagonListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
