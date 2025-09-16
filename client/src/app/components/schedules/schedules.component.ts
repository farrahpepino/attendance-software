import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { Day } from '../../models/Day';

@Component({
  selector: 'app-schedules',
  imports: [NavbarComponent, CommonModule, MatIconModule, FormsModule],
  templateUrl: './schedules.component.html',
  styleUrl: './schedules.component.css',
  standalone: true
})
export class SchedulesComponent {
  showForm = false;
  activeDay = 1;
  currentDay = 1;

  days: Day[] = [
    { id: 1, name: 'Monday' },
    { id: 2, name: 'Tuesday' },
    { id: 3, name: 'Wednesday' },
    { id: 4, name: 'Thursday' },
    { id: 5, name: 'Friday' },
    { id: 6, name: 'Saturday' },
    { id: 7, name: 'Sunday' },
  ];

  shifts = ['Shift 1', 'Shift 2', 'Shift 3', 'Break'];

  viewForm() {
    this.showForm = true;
  }

  hideForm() {
    this.showForm = false;
  }

  selectDay(day: number) {
    this.activeDay = day;
  }

  prevPage() {
    if (this.activeDay > 1) this.activeDay--;
  }

  nextPage() {
    if (this.activeDay < this.days.length) this.activeDay++;
  }

  isActive(day: number): boolean {
    return this.activeDay === day;
  }

  submitForm(event: Event){
    alert('Form submitted!');
    this.showForm = false;
  }

  prev(){
    if (this.currentDay > 1) this.currentDay--;
  }
  forward(){
    if (this.currentDay >= 1) this.currentDay++;
    if (this.currentDay>=8) this.currentDay=1;
  }
}
