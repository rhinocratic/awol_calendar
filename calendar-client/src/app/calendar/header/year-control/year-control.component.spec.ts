import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YearControlComponent } from './year-control.component';

describe('YearControlComponent', () => {
  let component: YearControlComponent;
  let fixture: ComponentFixture<YearControlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [YearControlComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(YearControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
