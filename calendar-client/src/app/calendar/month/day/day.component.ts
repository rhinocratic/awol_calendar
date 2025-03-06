import { Component, Input } from '@angular/core';
import { Day } from '../../../app-model';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-day',
  imports: [CommonModule],
  templateUrl: './day.component.html',
  styleUrl: './day.component.scss'
})

export class DayComponent {

  @Input() day!: Day;

}
