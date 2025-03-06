import { Component, inject, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Month, Day } from '../../app-model';
import { DayComponent } from './day/day.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatBadgeModule } from '@angular/material/badge';

@Component({
  selector: 'app-month',
  imports: [CommonModule, DayComponent, MatGridListModule, MatBadgeModule],
  templateUrl: './month.component.html',
  styleUrl: './month.component.scss'
})

export class MonthComponent {

  @Input() month!: Month;

  showDayDetail(day: Day): void {
    console.log(`day ${day.dayOfMonth} detail`);
  }

  hasNoEvents(day: Day): boolean {
    return day.events.length == 0;
  }
}
