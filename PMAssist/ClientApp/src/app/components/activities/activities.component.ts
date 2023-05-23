import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Activity } from '../../model/activity';

@Component({
  selector: 'app-activities',
  templateUrl: './activities.component.html',
  styleUrls: ['./activities.component.css']
})
export class ActivitiesComponent implements OnInit {
  @Input() activities = [];
  @Input() for = 'today';
/*  @Output() addWork = new EventEmitter<Activity[]>();*/

  ngOnInit(): void {

  }

  moveRight(userTask: any) {
    if (userTask.status === 'Planned') {
      userTask.status = 'In Progress'
    }
    else if (userTask.status === 'In Progress') {
      userTask.status = 'Completed'
    }
  }

  moveLeft(userTask: any) {
    if (userTask.status === 'Completed') {
      userTask.status = 'In Progress'
    }
    else if (userTask.status === 'In Progress') {
      userTask.status = 'Planned'
    }
  }
  planned(status:string):string {
    if (status === 'Planned')
      return 'planned';
    return 'undefined'
  }
}
