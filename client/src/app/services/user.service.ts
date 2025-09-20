import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = 'http://localhost:5131/user';
  constructor(private http: HttpClient) { }

  getAllUsers(): Observable<User[]>{
    return this.http.get<User[]>(`${this.apiUrl}`);
  }

  updateStatus(id: string, status: string){
    return this.http.put(`${this.apiUrl}/${id}/status`, `"${status}"`, 
    {headers: { 'Content-Type': 'application/json' }});
  }

  deleteUser(id: string){
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  getCurrentUser(){
    const userJson = localStorage.getItem('currentUser');
    return userJson ? JSON.parse(userJson) : null;
  }

}


