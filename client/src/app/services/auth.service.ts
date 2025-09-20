import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'http://localhost:5131/auth';
  constructor(private http: HttpClient) { }
  
  loginUser(userCode: number){
    return this.http.post(`${this.apiUrl}`, userCode, 
    {headers: { 'Content-Type': 'application/json' }});
  }
}
