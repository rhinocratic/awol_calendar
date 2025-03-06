import { Component, inject, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Month } from '../../app-model';
import { CalendarService } from '../../calendar.service';
import { DayComponent } from './day/day.component';
import { MatGridListModule } from '@angular/material/grid-list';

@Component({
  selector: 'app-month',
  imports: [CommonModule, DayComponent, MatGridListModule],
  templateUrl: './month.component.html',
  styleUrl: './month.component.scss'
})

export class MonthComponent {

  @Input() month!: Month | undefined;

}
