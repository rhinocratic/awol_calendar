import { Injectable } from '@angular/core';
import { Month } from './app-model';

@Injectable({
  providedIn: 'root'
})

export class CalendarService {

  url = 'http://localhost:3000/month';

  async getMonth(year: number, month: number): Promise<Month> {
    const data = await fetch(this.url);
    return (await data.json()) ?? {};
  }

  constructor() { }
}
