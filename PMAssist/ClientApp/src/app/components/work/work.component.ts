import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Work } from '../../model/work';

interface TaskType {
  value: string;
  name: string;
}

@Component({
  selector: 'app-work',
  templateUrl: './work.component.html',
  styleUrls: ['./work.component.css']
})
export class WorkComponent implements OnInit {
  @Input() disableDate = false;
  @Output() addWork = new EventEmitter<Work>();
  work: Work = { date: new Date(), planEffort: 0, type: '', userStory: '', what: '' }
  taskTypes: TaskType[] = [{ value: 'Analysis', name: 'Analysis' },
  { value: 'Design', name: 'Desing' },
  { value: 'Development', name: 'Development' },
  { value: 'Testing', name: 'Testing' },
  { value: 'Review', name: 'Review' },
  { value: 'Deploy', name: 'Deploy' }]

  ngOnInit(): void {

  }

  addTask() {
    this.addWork.emit(this.work);
  }
}
