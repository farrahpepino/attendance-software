import { Component } from '@angular/core';
import { RouterModule } from '@angular/router'; 
import { AuthService } from '../../services/auth.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-auth',
  imports: [RouterModule, ReactiveFormsModule, CommonModule],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css'
})
export class AuthComponent {
  constructor(private authService: AuthService, private router: Router){}
  loggedIn = true;
  form = new FormGroup({
    userCode: new FormControl('')
  });

  loginUser(){
    this.loggedIn=true;
    const code = this.form.value.userCode?.toString().trim();
    if (!code) return;

    this.authService.loginUser(Number(code)).subscribe({
      next: (data: any)=>{      
        localStorage.setItem('currentUser', JSON.stringify(data.user));
        localStorage.setItem('token', data.token);
        this.router.navigate(['/home']);
      },
      error: err => {
        this.loggedIn = false; 
        console.error('Error logging in:', err)
      }
    });
  }

}
