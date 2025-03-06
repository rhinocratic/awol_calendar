import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonthControlComponent } from './month-control.component';

describe('MonthControlComponent', () => {
  let component: MonthControlComponent;
  let fixture: ComponentFixture<MonthControlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MonthControlComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MonthControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
