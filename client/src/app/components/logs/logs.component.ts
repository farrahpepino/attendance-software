import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from '../navbar/navbar.component';
import { LogsService } from '../../services/logs.service';
import { Log } from '../../models/Log';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-logs',
  imports: [NavbarComponent, CommonModule],
  templateUrl: './logs.component.html',
  styleUrl: './logs.component.css'
})
export class LogsComponent implements OnInit {
  constructor(private logsService: LogsService){}
  logs: Log[] | null = null

  ngOnInit(): void {
    this.logsService.getAllLogs().subscribe({
      next: data=> {this.logs = data;}
    })
  }

}
