import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContainerTypeAndSizeComponent } from './container-type-and-size.component';

describe('ContainerTypeAndSizeComponent', () => {
  let component: ContainerTypeAndSizeComponent;
  let fixture: ComponentFixture<ContainerTypeAndSizeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ContainerTypeAndSizeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContainerTypeAndSizeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
