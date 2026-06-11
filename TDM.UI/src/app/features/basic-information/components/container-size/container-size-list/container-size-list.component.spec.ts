import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContainerSizeListComponent } from './container-size-list.component';

describe('ContainerSizeListComponent', () => {
  let component: ContainerSizeListComponent;
  let fixture: ComponentFixture<ContainerSizeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ContainerSizeListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContainerSizeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
