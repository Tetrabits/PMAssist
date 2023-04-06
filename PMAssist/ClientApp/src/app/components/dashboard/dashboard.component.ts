import { Component, OnInit } from '@angular/core';

export interface Project {
  name: string;
  sprintDuration: number;
  sprintNumber: number;
  startsOn: Date;
  endsOn: Date;
  duration: number;
  stories: Story[];
  bugs: Bug[];
  users: User[];
}

export interface Story {
  id: string;
  points: number;
}

export interface Bug {
  id: string;
  rca: string;
}

export interface User {
  name: string;
  yesterdayActivities: Activity[]
  activities: Activity[]
  futureActivities: Activity[]
}

export interface Activity {
  createdOn: Date;
  closedOn: Date;
  id: string;
  linkID: string;
  what: string;
  type: string;
  client: boolean;
  plan: number;
  totalSpent: number;
  actual: number;
  status: string;
}

export interface Effort {
  burntOn: Date;
  howMuch: number;
}
export interface Story {
  id: string;
  points: number;
}
export interface Work {
  howMuch: number;
}

//export interface Activity {
//  what: string;
//  work: Work[];
//}

//export interface User {
//  headers: string[];
//  details: Activity[]
//}

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

  project: Project =
    {
      name: 'Essete Upgrade 4.8',
      sprintDuration: 14,
      sprintNumber: 7,
      startsOn: new Date(),
      endsOn: new Date(),
      duration: 14,
      stories: [{ id: "US5589505", points: 2 },
      { id: "US5593556", points: 2 },
      { id: "US5593652", points: 2 },
      { id: "US5593680", points: 2 },
      { id: "US5527284", points: 2 },
      { id: "US5593850", points: 2 },
      { id: "US5593862", points: 2 },
      { id: "US5593897", points: 2 },
      { id: "US5593821", points: 2 },
      { id: "US5593924", points: 2 },
      { id: "US5593967", points: 2 }],
      bugs: [{ id: 'Bug 1', rca: 'Requirements missing' }],
      users: [
        {
          name: 'Gajanan Tuppad', yesterdayActivities: [
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589928", what: "", type: "Code Review", client: true, status: "Planned", "plan": 0.5, "totalSpent": 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590199", what: "", type: "Code Review", client: true, status: "Planned", "plan": 0.5, "totalSpent": 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590637", what: "", type: "Code Review", client: true, status: "Planned", "plan": 0.5, "totalSpent": 4, "actual": 0 }
          ], activities: [], futureActivities: []
        },
        {
          name: 'Rushikesh Thakare', yesterdayActivities: [
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590197", what: "", type: "Analysis",  client: true, status:"Completed", plan: 2, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590197", what: "", type: "Development",  client: true, status:"Completed", plan: 1, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589502", what: "", type: "Analysis",  client: true, status:"Completed", plan: 2, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589502", what: "", type: "Development",  client: true, status:"Completed", plan: 1, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589505", what: "", type: "Analysis",  client: true, status:"Completed", plan: 2, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589505", what: "", type: "Development",  client: true, status:"Completed", plan: 1, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593556", what: "", type: "Analysis",  client: true, status:"Planned", plan: 2, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593556", what: "", type: "Development",  client: true, status:"Planned", plan: 1, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593652", what: "", type: "Analysis",  client: true, status:"Planned", plan: 2, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593652", what: "", type: "Development",  client: true, status:"Planned", plan: 1, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593680", what: "", type: "Analysis",  client: true, status:"Planned", plan: 2, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593680", what: "", type: "Development",  client: true, status:"Planned", plan: 1, totalSpent: 4, "actual": 0 }
          ], activities: [], futureActivities: []
        },
        {
          name: 'Madhu Gurukar', yesterdayActivities: [
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589928", what: "", "type": "Analysis",  client: true, status: "Planned", plan: 2, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589928", what: "", "type": "Development",  client: true, status: "Planned", plan: 1, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590199", what: "", "type": "Analysis",  client: true, status: "Planned", plan: 2, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590199", what: "", "type": "Development",  client: true, status: "Planned", plan: 1, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593026", what: "", "type": "Analysis",  client: true, status: "Planned", plan: 2, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590637", what: "", "type": "Development",  client: true, status: "Planned", plan: 1, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590197", what: "", "type": "Code Review",  client: true, status: "Planned", plan: 0.5, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589502", what: "", "type": "Code Review",  client: true, status: "Planned", plan: 0.5, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589505", what: "", "type": "Code Review",  client: true, status: "Planned", plan: 0.5, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593556", what: "", "type": "Code Review",  client: true, status: "Planned", plan: 0.5, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593652", what: "", "type": "Code Review",  client: true, status: "Planned", plan: 0.5, totalSpent: 4, "actual": 0 },
            { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593680", what: "", "type": "Code Review",  client: true, status: "Planned", plan: 0.5, totalSpent: 4, "actual": 0 }
          ], activities: [], futureActivities: []
        }],
    };

  ngOnInit(): void {



  }

  startDateSelected(event: any) {
    //let date = new Date();
    //date.setDate(this.startsOn.getDate() + 3)
    //this.endsOn.setDate(this.startsOn.getDate() + 3);
    //this.endsOn = date;
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

  addTask(work: any, userWork: any) {
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
