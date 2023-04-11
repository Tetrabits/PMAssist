import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Activity } from '../../model/activity';

interface TaskType {
  value: string;
  name: string;
}

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.css']
})
export class ActivityComponent implements OnInit {
  @Input() for = 'today';
  @Output() addWork = new EventEmitter<Activity>();
  activity: Activity = { createdOn: new Date(), plan: 0, type: '', what: '', client:true, status:'Planned'}
  taskTypes: TaskType[] = [{ value: 'Analysis', name: 'Analysis' },
  { value: 'Design', name: 'Desing' },
  { value: 'Development', name: 'Development' },
  { value: 'Testing', name: 'Testing' },
  { value: 'Review', name: 'Review' },
  { value: 'Deploy', name: 'Deploy' }]

  minDate: Date = new Date();
  maxDate: Date = new Date();

  ngOnInit(): void {
    this.minDate.setDate(new Date().getDate() - 1);
    this.maxDate.setDate(new Date().getDate() + 30);
  }

  addTask() {
    this.addWork.emit(this.activity);
  }

}
