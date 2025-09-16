import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-schedules',
  imports: [NavbarComponent, CommonModule, MatIconModule],
  templateUrl: './schedules.component.html',
  styleUrl: './schedules.component.css'
})
export class SchedulesComponent {
  activeDay = 1;
  showForm = false;

  viewForm(){
    this.showForm = true;
  }

  hideForm(){
    this.showForm = false;
  }
  
  selectDay(day: number){
    this.activeDay = day;
  }

}
