import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContainerTypeAndSizeListComponent } from './container-type-and-size-list.component';

describe('ContainerTypeAndSizeListComponent', () => {
  let component: ContainerTypeAndSizeListComponent;
  let fixture: ComponentFixture<ContainerTypeAndSizeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ContainerTypeAndSizeListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContainerTypeAndSizeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
