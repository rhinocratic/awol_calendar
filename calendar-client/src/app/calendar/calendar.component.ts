import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { HeaderComponent } from './header/header.component';
import { MonthComponent } from './month/month.component';
import { CalendarService } from '../calendar.service';
import { Month } from '../app-model';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-calendar',
  imports: [CommonModule, HeaderComponent, MonthComponent, MatCardModule],
  templateUrl: './calendar.component.html',
  styleUrl: './calendar.component.scss'
})

export class CalendarComponent {

  calendarService: CalendarService = inject(CalendarService);
  month: Month | undefined;

  constructor() {
    this.calendarService.getMonth(2025, 3).then((month: Month) => {
      this.month = month;
    });
  }
}
