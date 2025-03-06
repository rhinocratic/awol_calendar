import { Injectable } from '@angular/core';
import { EventUpdate, Month } from './app-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class CalendarService {

  baseUrl = 'http://localhost:5244';

  constructor() { }

  async getMonth(year: number, month: number): Promise<Month> {
    const data = await fetch(`${this.baseUrl}/api/events/${year}/${month}`);
    return (await data.json()) ?? {};
  }

  getEventUpdates(): string {
    return `${this.baseUrl}/event-update-stream`;
  }

}
