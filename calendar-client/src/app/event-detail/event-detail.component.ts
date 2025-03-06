import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { MatTimepickerModule } from '@angular/material/timepicker';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { provideNativeDateAdapter } from '@angular/material/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-event-detail',
  imports: [CommonModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatTimepickerModule],
  providers: [provideNativeDateAdapter()],
  templateUrl: './event-detail.component.html',
  styleUrl: './event-detail.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class EventDetailComponent {


}
