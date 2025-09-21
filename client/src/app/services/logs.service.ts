import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Log } from '../models/Log';

@Injectable({
  providedIn: 'root'
})
export class LogsService {

  private apiUrl = 'http://localhost:5131/log';
  constructor(private http: HttpClient) { }

  getAllLogs(): Observable<Log[]>{
    return this.http.get<Log[]>(`${this.apiUrl}`);
  }

}
