import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Day } from '../../models/Day';
import { ScheduleService } from '../../services/schedule.service';
import { Schedule } from '../../models/Schedule';

@Component({
  selector: 'app-schedules',
  imports: [NavbarComponent, CommonModule, ReactiveFormsModule],
  templateUrl: './schedules.component.html',
  styleUrl: './schedules.component.css',
  standalone: true
})

export class SchedulesComponent {
  constructor(private scheduleService: ScheduleService){}

  scheduleForm = new FormGroup({
    name: new FormControl(''),

    mon_shift1: new FormControl(''),
    mon_shift2: new FormControl(''),
    mon_shift3: new FormControl(''),
    mon_break: new FormControl(''),

    tue_shift1: new FormControl(''),
    tue_shift2: new FormControl(''),
    tue_shift3: new FormControl(''),
    tue_break: new FormControl(''),

    wed_shift1: new FormControl(''),
    wed_shift2: new FormControl(''),
    wed_shift3: new FormControl(''),
    wed_break: new FormControl(''),

    thu_shift1: new FormControl(''),
    thu_shift2: new FormControl(''),
    thu_shift3: new FormControl(''),
    thu_break: new FormControl(''),

    fri_shift1: new FormControl(''),
    fri_shift2: new FormControl(''),
    fri_shift3: new FormControl(''),
    fri_break: new FormControl(''),

    sat_shift1: new FormControl(''),
    sat_shift2: new FormControl(''),
    sat_shift3: new FormControl(''),
    sat_break: new FormControl(''),

    sun_shift1: new FormControl(''),
    sun_shift2: new FormControl(''),
    sun_shift3: new FormControl(''),
    sun_break: new FormControl(''),


  });

  showForm = false;
  activeDay = 1;

  days: Day[] = [
    { id: 1, name: 'Monday' },
    { id: 2, name: 'Tuesday' },
    { id: 3, name: 'Wednesday' },
    { id: 4, name: 'Thursday' },
    { id: 5, name: 'Friday' },
    { id: 6, name: 'Saturday' },
    { id: 7, name: 'Sunday' },
  ];

  viewForm() {
    this.showForm = true;
  }

  hideForm() {
    this.showForm = false;
  }

  selectDay(day: number) {
    this.activeDay = day;
  }

  isActive(day: number): boolean {
    return this.activeDay === day;
  }

  submitForm(){
    const schedule: Schedule = {};

    Object.keys(this.scheduleForm.controls).forEach(key => {
      let value = this.scheduleForm.get(key)?.value;

      value = value.replace(/\s+/g, '').toLowerCase();

      if (value === 'null'){
        value = undefined;
      }  
      schedule[key as keyof Schedule] = value;

    });

    this.scheduleService.createSchedule(schedule).subscribe({
      next: res => {
        console.log('Schedule saved', res);
        this.showForm = false;
      },
      error: err => console.error('Error saving schedule:', err)
    });
  }

}
