import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';
import { User } from '../../models/User';
import { LogsService } from '../../services/logs.service';
import { Log } from '../../models/Log';

enum Active {
  Absent = 'absent',
  Present = 'present',
}
@Component({
  selector: 'app-home',
  imports: [NavbarComponent, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})

export class HomeComponent implements OnInit {
  constructor (private userService: UserService){}
  users: User[] = []
  currentUser: User | null = null;
  currentDate: Date = new Date();
  status: Active = Active.Present;
  Active = Active;

  ngOnInit(): void {
      this.currentUser = this.userService.getCurrentUser();
      this.userService.getAllUsers().subscribe({
        next: (data)=>{
          this.users = data
        }
      });
  }

  toggleStatus(status: string){
    if (status === 'present'){
      this.status = Active.Present;
    } 
    else {
      this.status = Active.Absent;
    }
  }
  
  onSelect(event: Event, user: User){
    const value = (event.target as HTMLSelectElement).value;
    if (value === 'present' || value === 'absent') {
      this.userService.updateStatus(user.id, value).subscribe(() => {
        user.status = value;
      });
    } 
    (event.target as HTMLSelectElement).selectedIndex = -1;
  }
}
