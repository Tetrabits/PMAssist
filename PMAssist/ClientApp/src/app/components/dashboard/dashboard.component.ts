import { Component, OnInit } from '@angular/core';
export interface Story {
  id: string;
  points: number;
}
export interface Work {
  howMuch: number;
}

export interface Activity {
  what: string;
  work: Work[];
}

export interface User {
  headers: string[];
  details: Activity[]
}

export interface EffortCategory {
  id: number;
  name: string;

}

interface TaskType {
  value: string;
  name: string;
}
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {


  users: User = { headers: [], details: [] };
  startsOn: Date = new Date();
  endsOn: Date = new Date();
  stories: Story[] = [];
  tasks: any = [{ "who": "Madhu Gurukar", userStory: "US5589928", what: "", "type": "Analysis", "status": "Planned", "planned": 2 },
  { "who": "Madhu Gurukar", userStory: "US5589928", what: "", "type": "Development", "status": "Planned", "planned": 1 },
  { "who": "Gajanan Tuppad", userStory: "US5589928", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5 },
  { "who": "Madhu Gurukar", userStory: "US5590199", what: "", "type": "Analysis", "status": "Planned", "planned": 2 },
  { "who": "Madhu Gurukar", userStory: "US5590199", what: "", "type": "Development", "status": "Planned", "planned": 1 },
  { "who": "Gajanan Tuppad", userStory: "US5590199", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5 },
  { "who": "Madhu Gurukar", userStory: "US5593026", what: "", "type": "Analysis", "status": "Planned", "planned": 2 },
  { "who": "Madhu Gurukar", userStory: "US5590637", what: "", "type": "Development", "status": "Planned", "planned": 1 },
  { "who": "Gajanan Tuppad", userStory: "US5590637", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5 },
  { "who": "Rushikesh Thakare", userStory: "US5590197", what: "", "type": "Analysis", "status": "Completed", "planned": 2 },
  { "who": "Rushikesh Thakare", userStory: "US5590197", what: "", "type": "Development", "status": "Completed", "planned": 1 },
  { "who": "Madhu Gurukar", userStory: "US5590197", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5 },
  { "who": "Rushikesh Thakare", userStory: "US5589502", what: "", "type": "Analysis", "status": "Completed", "planned": 2 },
  { "who": "Rushikesh Thakare", userStory: "US5589502", what: "", "type": "Development", "status": "Completed", "planned": 1 },
  { "who": "Madhu Gurukar", userStory: "US5589502", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5 },
  { "who": "Rushikesh Thakare", userStory: "US5589505", what: "", "type": "Analysis", "status": "Completed", "planned": 2 },
  { "who": "Rushikesh Thakare", userStory: "US5589505", what: "", "type": "Development", "status": "Completed", "planned": 1 },
  { "who": "Madhu Gurukar", userStory: "US5589505", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5 },
  { "who": "Rushikesh Thakare", userStory: "US5593556", what: "", "type": "Analysis", "status": "Planned", "planned": 2 },
  { "who": "Rushikesh Thakare", userStory: "US5593556", what: "", "type": "Development", "status": "Planned", "planned": 1 },
  { "who": "Madhu Gurukar", userStory: "US5593556", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5 },
  { "who": "Rushikesh Thakare", userStory: "US5593652", what: "", "type": "Analysis", "status": "Planned", "planned": 2 },
  { "who": "Rushikesh Thakare", userStory: "US5593652", what: "", "type": "Development", "status": "Planned", "planned": 1 },
  { "who": "Madhu Gurukar", userStory: "US5593652", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5 },
  { "who": "Rushikesh Thakare", userStory: "US5593680", what: "", "type": "Analysis", "status": "Planned", "planned": 2 },
  { "who": "Rushikesh Thakare", userStory: "US5593680", what: "", "type": "Development", "status": "Planned", "planned": 1 },
  { "who": "Madhu Gurukar", userStory: "US5593680", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5 }]

  userTasks: any = [{
    user: "Madhu Gurukar", "yesterdayTasks": [
      { userStory: "US5589928", what: "", "type": "Analysis", "status": "Planned", "planned": 2, "spent":4, "actual": 0 },
      { userStory: "US5589928", what: "", "type": "Development", "status": "Planned", "planned": 1, "spent": 4, "actual": 0 },
      { userStory: "US5590199", what: "", "type": "Analysis", "status": "Planned", "planned": 2, "spent":4, "actual": 0 },
      { userStory: "US5590199", what: "", "type": "Development", "status": "Planned", "planned": 1, "spent":4, "actual": 0 },
      { userStory: "US5593026", what: "", "type": "Analysis", "status": "Planned", "planned": 2, "spent":4, "actual": 0 },
      { userStory: "US5590637", what: "", "type": "Development", "status": "Planned", "planned": 1, "spent":4, "actual": 0 },
      { userStory: "US5590197", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5, "spent":4, "actual": 0 },
      { userStory: "US5589502", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5, "spent":4, "actual": 0 },
      { userStory: "US5589505", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5, "spent":4, "actual": 0 },
      { userStory: "US5593556", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5, "spent":4, "actual": 0 },
      { userStory: "US5593652", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5, "spent":4, "actual": 0 },
      { userStory: "US5593680", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5, "spent":4, "actual": 0 }],
    "tasks": [],
    "futureTasks": [],
    "today": { date: new Date(), userStory: '', what: '', "type": '', "planned": 0 },
    "future": { date: new Date(), userStory: '', what: '', type: '', planned: 0 },
    "showToday": true,
    "userStory": '',
    "what": '',
    "type": '',
    "planned": 0
  },
  {
    "user": "Gajanan Tuppad", "yesterdayTasks": [
      { userStory: "US5589928", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5, "spent":4, "actual": 0 },
      { userStory: "US5590199", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5, "spent":4, "actual": 0 },
      { userStory: "US5590637", what: "", "type": "Code Review", "status": "Planned", "planned": 0.5, "spent":4, "actual": 0 }],
    "tasks": [],
    "futureTasks": [],
    "today": { date: new Date(), userStory: '', what: '', "type": '', "planned": 0 },
    "future": { date: new Date(), userStory: '', what: '', "type": '', "planned": 0 },
    "showToday": true,
    "userStory": '',
    "what": '',
    "type": '',
    "planned": 0
  },
  {
    "user": "Rushikesh Thakare", "yesterdayTasks": [
      { userStory: "US5590197", what: "", "type": "Analysis", "status": "Completed", "planned": 2, "spent":4, "actual": 0 },
      { userStory: "US5590197", what: "", "type": "Development", "status": "Completed", "planned": 1, "spent":4, "actual": 0 },
      { userStory: "US5589502", what: "", "type": "Analysis", "status": "Completed", "planned": 2, "spent":4, "actual": 0 },
      { userStory: "US5589502", what: "", "type": "Development", "status": "Completed", "planned": 1, "spent":4, "actual": 0 },
      { userStory: "US5589505", what: "", "type": "Analysis", "status": "Completed", "planned": 2, "spent":4, "actual": 0 },
      { userStory: "US5589505", what: "", "type": "Development", "status": "Completed", "planned": 1, "spent":4, "actual": 0 },
      { userStory: "US5593556", what: "", "type": "Analysis", "status": "Planned", "planned": 2, "spent":4, "actual": 0 },
      { userStory: "US5593556", what: "", "type": "Development", "status": "Planned", "planned": 1, "spent":4, "actual": 0 },
      { userStory: "US5593652", what: "", "type": "Analysis", "status": "Planned", "planned": 2, "spent":4, "actual": 0 },
      { userStory: "US5593652", what: "", "type": "Development", "status": "Planned", "planned": 1, "spent":4, "actual": 0 },
      { userStory: "US5593680", what: "", "type": "Analysis", "status": "Planned", "planned": 2, "spent":4, "actual": 0 },
      { userStory: "US5593680", what: "", "type": "Development", "status": "Planned", "planned": 1, "spent":4, "actual": 0 }],
    "tasks": [],
    "futureTasks": [],
    "today": { date: new Date(), userStory: '', what: '', "type": '', "planned": 0 },
    "future": { date: new Date(), userStory: '', what: '', "type": '', "planned": 0},
    "showToday": true,
    "userStory": '',
    "what": '',
    "type": '',
    "planned": 0
  }];

  effortCategories: EffortCategory[] = [{ id: 1, name: 'Planned' }, { id: 2, name: 'Active' }, { id: 3, name: 'Completed' }];
  taskTypes: TaskType[] = [{ value: 'Analysis', name: 'Analysis' }]

  ngOnInit(): void {

    this.users = {
      headers: ['01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14'],
      details: [{ what: 'Task1', work: [{ howMuch: 1 }, { howMuch: 2 }, { howMuch: 3 }, { howMuch: 4 }, { howMuch: 5 }, { howMuch: 6 }, { howMuch: 7 }, { howMuch: 8 }, { howMuch: 9 }, { howMuch: 10 }, { howMuch: 11 }, { howMuch: 12 }, { howMuch: 13 }, { howMuch: 14 }] },
      { what: 'Task2', work: [{ howMuch: 14 }, { howMuch: 13 }, { howMuch: 12 }, { howMuch: 11 }, { howMuch: 10 }, { howMuch: 9 }, { howMuch: 8 }, { howMuch: 7 }, { howMuch: 6 }, { howMuch: 5 }, { howMuch: 4 }, { howMuch: 3 }, { howMuch: 2 }, { howMuch: 1 }] }]
    };

    this.stories = [{ id: 'US90978', points: 5 }, { id: 'US90978', points: 8 }]

  }

  startDateSelected(event: any) {
    let date = new Date();
    date.setDate(this.startsOn.getDate() + 3)
    //this.endsOn.setDate(this.startsOn.getDate() + 3);
    this.endsOn = date;
  }

  clickToday(userTasks: any) {
    for (let i = userTasks.tasks.length - 1; i > -1; i--) {
      if (userTasks.tasks[i].status === 3) {
        userTasks.yesterdayTasks.push(userTasks.tasks[i]);
        userTasks.tasks.splice(i, 1);
      }
      else { }
    }
    userTasks.showToday = true;
  }

  closeDay(userTasks: any) {
    for (let i = userTasks.yesterdayTasks.length - 1; i > -1; i--) {
      if (userTasks.yesterdayTasks[i].status !== 'Completed') {
        userTasks.tasks.push(userTasks.yesterdayTasks[i]);
        userTasks.yesterdayTasks.splice(i, 1);
      }
      else { }
    }
    userTasks.showToday = true;
  }

  addTask(work: any, userWork:any) {
    userWork.tasks.push({
      "date": work.date,
      "userStory": work.userStory,
      "what": work.what,
      "type": work.type.value,
      "planned": work.planEffort,
      "status": "Planned"
    })
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

  addFutureTask(userTasks: any, userWork: any) {
    userWork.futureTasks.push({
      "date": userTasks.date,
      "userStory": userTasks.userStory,
      "what": userTasks.what,
      "type": userTasks.type.value,
      "planned": userTasks.planned,
      "status": "Planned"
    })
  }
}
