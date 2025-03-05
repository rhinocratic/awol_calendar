import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { YearControlComponent } from './year-control/year-control.component';
import { MonthControlComponent } from './month-control/month-control.component';

@Component({
  selector: 'app-header',
  imports: [CommonModule, YearControlComponent, MonthControlComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})

export class HeaderComponent {

}
