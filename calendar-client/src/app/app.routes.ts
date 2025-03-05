import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { inject } from '@angular/core';
import { NotFoundComponent } from './not-found/not-found.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: () => {
      let today = new Date();
      return `calendar/${today.getFullYear()}/${today.getMonth() + 1}`;;
    },
    pathMatch: 'full'
  },
  {
    path: 'calendar/:year/:month',
    component: HomeComponent,
    title: 'Calendar Application',
  },
  {
    path: 'calendar/:year/:month/:day',
    component: HomeComponent,
    title: 'Calendar Application',
  },
  {
    path: 'events/:event-id',
    component: HomeComponent,
    title: 'Calendar Application',
  },
  { path: '**', component: NotFoundComponent }
];
