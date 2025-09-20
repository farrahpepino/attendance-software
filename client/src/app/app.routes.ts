import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { SchedulesComponent } from './components/schedules/schedules.component';
import { TutorsComponent } from './components/tutors/tutors.component';
import { AuthComponent } from './components/auth/auth.component';
import { authGuard } from './guards/auth.guard';
import { loginGuard } from './guards/login.guard';

export const routes: Routes = [
    {
        path: '',
        component: AuthComponent,
        canActivate: [loginGuard]
    },
    {
        path: 'home',
        component: HomeComponent,
        canActivate: [authGuard]
    },
    {
        path: 'schedules',
        component: SchedulesComponent,
        canActivate: [authGuard]
    },
    {
        path: 'tutors',
        component: TutorsComponent,
        canActivate: [authGuard]
    }
];
