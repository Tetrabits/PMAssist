import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  user: any;
  ngOnInit(): void {
    localStorage.getItem('user');
    this.user = JSON.parse(localStorage.getItem('user')!);
  }

}
