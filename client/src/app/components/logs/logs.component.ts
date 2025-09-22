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
  logs: Log[] | null = null;
  groupedLogs: { date: string, logs: Log[] }[] = [];


  ngOnInit(): void {
    this.logsService.getAllLogs().subscribe({
      next: data => {
        this.logs = data;

        const grouped = data.reduce((acc:any, log:Log)=>{
          const date = new Date(log.createdAt).toDateString();
          if (!acc[date]) acc[date]=[];
          acc[date].push(log);
          return acc;
        }, {});
       
        this.groupedLogs = Object.keys(grouped).map(date => ({
           date,
           logs: grouped[date]
         }))
         .sort((firstItem, secondItem)=> new Date(secondItem.date).getTime()- new Date(firstItem.date).getTime());
      }

      
    });
  }
}
