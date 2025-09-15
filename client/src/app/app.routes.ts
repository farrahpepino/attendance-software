import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SchedulesComponent } from './components/schedules/schedules.component';
import { TutorsComponent } from './components/tutors/tutors.component';

export const routes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'schedules',
        component: SchedulesComponent
    },
    {
        path: 'tutors',
        component: TutorsComponent
    }
];
