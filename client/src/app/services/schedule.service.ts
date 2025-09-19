import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from './user.service';
import { Schedule } from '../models/Schedule';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {

  private apiUrl = 'http://localhost:5131/schedule';
  constructor(private http: HttpClient, private userService: UserService) { }

  createSchedule(data: Schedule): Observable<Schedule> {
    return this.http.post<Schedule>(`${this.apiUrl}`, data);
  }


}
