export interface Interval {
  start: Date;
  end: Date;
}

export interface Event {
  id: string;
  title: string;
  interval: Interval;
  description: string;
  location: string;
}

export interface Day {
  dayOfMonth: number;
  enabled: boolean;
  events: Event[];
}

export interface Month {
  yearName: string;
  monthName: string;
  dayNames: string;
  days: [Day];
}
