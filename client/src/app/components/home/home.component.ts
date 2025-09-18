import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { CommonModule } from '@angular/common';

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

export class HomeComponent {
  currentDate: Date = new Date();
  status: Active = Active.Present;
  Active = Active;

  toggleStatus(status: string){
    if (status === 'present'){
      this.status = Active.Present;
    } 
    else {
      this.status = Active.Absent;
    }
  }
  onSelect(event: Event){
    (event.target as HTMLSelectElement).selectedIndex = -1;
  }
}
