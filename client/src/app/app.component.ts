import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SchedulesComponent } from './components/schedules/schedules.component';
import { TutorsComponent } from './components/tutors/tutors.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HomeComponent, SchedulesComponent, TutorsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'client';
}
