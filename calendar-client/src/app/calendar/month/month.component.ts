import { Component, inject, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Month } from '../../app-model';
import { CalendarService } from '../../calendar.service';
import { DayComponent } from './day/day.component';

@Component({
  selector: 'app-month',
  imports: [CommonModule, DayComponent],
  template: `
    <section class= "day" >
      <app-day *ngFor="let day of month?.days" [day]="day">
      </app-day>
    </section>
  `,
  // templateUrl: './month.component.html',
  styleUrl: './month.component.scss'
})

export class MonthComponent {

  @Input() month!: Month | undefined;

}
