import { Component } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';

@Component({
  selector: 'app-tutors',
  imports: [NavbarComponent],
  templateUrl: './tutors.component.html',
  styleUrl: './tutors.component.css'
})
export class TutorsComponent {

  onSelect(event: Event){
    (event.target as HTMLSelectElement).selectedIndex = -1;
  }
}
