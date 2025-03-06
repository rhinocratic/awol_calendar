import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { YearControlComponent } from './year-control/year-control.component';
import { MonthControlComponent } from './month-control/month-control.component';
import { MatListModule } from '@angular/material/list';
import { MatDividerModule } from '@angular/material/divider';
import { Month } from '../../app-model';

@Component({
  selector: 'app-header',
  imports: [CommonModule, YearControlComponent, MonthControlComponent, MatListModule, MatDividerModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})

export class HeaderComponent {

  @Input() month!: Month | undefined;

}
