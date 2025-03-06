import { Component, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Month } from '../../../app-model';

@Component({
  selector: 'app-month-control',
  imports: [MatButtonModule, MatIconModule],
  templateUrl: './month-control.component.html',
  styleUrl: './month-control.component.scss'
})
export class MonthControlComponent {

  @Input() month!: Month | undefined;

}
