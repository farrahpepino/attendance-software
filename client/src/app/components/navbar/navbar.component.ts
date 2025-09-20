import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UserService } from '../../services/user.service';
import { User } from '../../models/User';
import { Router } from '@angular/router';
@Component({
  selector: 'app-navbar',
  imports: [RouterModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})

export class NavbarComponent implements OnInit {
  constructor (private router: Router, private userService: UserService){}
  currentUser: User | null = null;

  ngOnInit(): void {
    this.currentUser = this.userService.getCurrentUser();
  }

  logOut(){
    localStorage.clear();
    this.router.navigate(['/']);
  }
}
