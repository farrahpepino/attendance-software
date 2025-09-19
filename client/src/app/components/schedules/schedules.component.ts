import { Component , OnInit} from '@angular/core';
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

export class SchedulesComponent implements OnInit {
  constructor(private scheduleService: ScheduleService){}
  schedules:Schedule[]=[]

  ngOnInit(): void {
      this.scheduleService.getAllSchedules().subscribe({
        next: (data: Schedule[]) => {
          this.schedules = data
          console.log('All schedules:', this.schedules);
        },
        error: err => console.error('Error getting schedules:', err)
      })
  }

  scheduleForm = new FormGroup({
    name: new FormControl(''),

    mon_Shift1: new FormControl(''),
    mon_Shift2: new FormControl(''),
    mon_Shift3: new FormControl(''),
    mon_Break: new FormControl(''),

    tue_Shift1: new FormControl(''),
    tue_Shift2: new FormControl(''),
    tue_Shift3: new FormControl(''),
    tue_Break: new FormControl(''),

    wed_Shift1: new FormControl(''),
    wed_Shift2: new FormControl(''),
    wed_Shift3: new FormControl(''),
    wed_Break: new FormControl(''),

    thu_Shift1: new FormControl(''),
    thu_Shift2: new FormControl(''),
    thu_Shift3: new FormControl(''),
    thu_Break: new FormControl(''),

    fri_Shift1: new FormControl(''),
    fri_Shift2: new FormControl(''),
    fri_Shift3: new FormControl(''),
    fri_Break: new FormControl(''),

    sat_Shift1: new FormControl(''),
    sat_Shift2: new FormControl(''),
    sat_Shift3: new FormControl(''),
    sat_Break: new FormControl(''),

    sun_Shift1: new FormControl(''),
    sun_Shift2: new FormControl(''),
    sun_Shift3: new FormControl(''),
    sun_Break: new FormControl(''),


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

      // value = value.replace(/\s+/g, '').toLowerCase();

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
