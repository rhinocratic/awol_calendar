import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { CalendarComponent } from '../calendar/calendar.component';

@Component({
  selector: 'app-home',
  imports: [CommonModule, CalendarComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})

export class HomeComponent {


}
