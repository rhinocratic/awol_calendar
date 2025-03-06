import { Component, Input } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Month } from '../../../app-model';

@Component({
  selector: 'app-year-control',
  imports: [MatButtonModule, MatIconModule],
  templateUrl: './year-control.component.html',
  styleUrl: './year-control.component.scss'
})

export class YearControlComponent {

  @Input() month!: Month | undefined;

  decrementYear(): void {
    console.log("Decrement");
  }

  incrementYear(): void {
    console.log("Increment");
  }

}
