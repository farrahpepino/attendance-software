import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { UserService } from '../../services/user.service';
import { User } from '../../models/User';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-tutors',
  imports: [NavbarComponent, CommonModule],
  templateUrl: './tutors.component.html',
  styleUrl: './tutors.component.css'
})

export class TutorsComponent implements OnInit {
  constructor (private userService: UserService){}
  users: User[] = []
  currentUser: User | null = null;


  ngOnInit(): void {
      this.currentUser = this.userService.getCurrentUser();
      this.userService.getAllUsers().subscribe({
        next: (data)=>{
          this.users = data
        }
      });
  }

  onSelect(event: Event, user: User){
    
    const value = (event.target as HTMLSelectElement).value;

    if (value === 'present' || value === 'absent') {
      this.userService.updateStatus(user.id, value).subscribe(() => {
        user.status = value;
      });
    } else if (value === 'remove') {
      this.userService.deleteUser(user.id).subscribe(() => {
        this.users = this.users.filter(u => u.id !== user.id);
      });
    }
    (event.target as HTMLSelectElement).selectedIndex = -1;

  }
}
