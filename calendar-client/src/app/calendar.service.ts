import { Injectable } from '@angular/core';
import { Month } from './calendar/month/month';

@Injectable({
  providedIn: 'root'
})

export class CalendarService {

  url = 'http://localhost:3000/month';

  async getMonth(): Promise<Month> {
    const data = await fetch(this.url);
    return (await data.json()) ?? {};
  }

  constructor() { }
}
