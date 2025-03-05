import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Month } from './month';
import { CalendarService } from '../../calendar.service';

@Component({
  selector: 'app-month',
  imports: [CommonModule],
  templateUrl: './month.component.html',
  styleUrl: './month.component.scss'
})

export class MonthComponent {

  month: Month = {};
  calendarService: CalendarService = inject(CalendarService);

  constructor() {
    this.month = this.calendarService.getMonth();
  }

}
