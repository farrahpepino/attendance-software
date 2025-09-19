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

  ngOnInit(): void {
      this.userService.getAllUsers().subscribe({
        next: (data)=>{
          this.users = data
          console.log('All tutors:', this.users);
        }
      });
  }

  onSelect(event: Event){
    (event.target as HTMLSelectElement).selectedIndex = -1;
  }
}
