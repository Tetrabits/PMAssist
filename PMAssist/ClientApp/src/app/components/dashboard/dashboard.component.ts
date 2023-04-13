import { Component, OnInit } from '@angular/core';
import { Activity } from '../../model/activity';
import { ScrumService } from '../../shared/services/scrum.service';
import { ProjectService } from '../../shared/services/project.service';


export interface Project {
  name: string;
  projectKey?: string;
  sprintDuration: number;
  sprintNumber: number;
  sprints: sprint[];
  startsOn: Date;
  endsOn: Date;
  duration: number;
  stories: Story[];
  bugs: Bug[];
  users: User[];
}

export interface sprint {
  duration: number;
  key: string;
  endsOn: Date;
  number: number;
  startsOn: Date;
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

export interface Effort {
  burntOn: Date;
  howMuch: number;
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

  //project: Project =
  //  {
  //    name: 'Essete Upgrade 4.8',
  //    sprintDuration: 14,
  //    sprintNumber: 7,
  //    startsOn: new Date(),
  //    endsOn: new Date(),
  //    duration: 14,
  //    stories: [{ id: "US5589505", points: 2 },
  //    { id: "US5593556", points: 2 },
  //    { id: "US5593652", points: 2 },
  //    { id: "US5593680", points: 2 },
  //    { id: "US5527284", points: 2 },
  //    { id: "US5593850", points: 2 },
  //    { id: "US5593862", points: 2 },
  //    { id: "US5593897", points: 2 },
  //    { id: "US5593821", points: 2 },
  //    { id: "US5593924", points: 2 },
  //    { id: "US5593967", points: 2 }],
  //    bugs: [{ id: 'Bug 1', rca: 'Requirements missing' }],
  //    users: [
  //      {
  //        name: 'Gajanan Tuppad', yesterdayActivities: [
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589928", what: "", type: "Code Review", client: true, status: "Planned", "plan": 0.5, "totalSpent": 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590199", what: "", type: "Code Review", client: true, status: "Planned", "plan": 0.5, "totalSpent": 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590637", what: "", type: "Code Review", client: true, status: "Planned", "plan": 0.5, "totalSpent": 4, "actual": 0 }
  //        ], activities: [], futureActivities: []
  //      },
  //      {
  //        name: 'Rushikesh Thakare', yesterdayActivities: [
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590197", what: "", type: "Analysis",  client: true, status:"Completed", plan: 2, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590197", what: "", type: "Development",  client: true, status:"Completed", plan: 1, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589502", what: "", type: "Analysis",  client: true, status:"Completed", plan: 2, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589502", what: "", type: "Development",  client: true, status:"Completed", plan: 1, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589505", what: "", type: "Analysis",  client: true, status:"Completed", plan: 2, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589505", what: "", type: "Development",  client: true, status:"Completed", plan: 1, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593556", what: "", type: "Analysis",  client: true, status:"Planned", plan: 2, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593556", what: "", type: "Development",  client: true, status:"Planned", plan: 1, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593652", what: "", type: "Analysis",  client: true, status:"Planned", plan: 2, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593652", what: "", type: "Development",  client: true, status:"Planned", plan: 1, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593680", what: "", type: "Analysis",  client: true, status:"Planned", plan: 2, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593680", what: "", type: "Development",  client: true, status:"Planned", plan: 1, totalSpent: 4, "actual": 0 }
  //        ], activities: [], futureActivities: []
  //      },
  //      {
  //        name: 'Madhu Gurukar', yesterdayActivities: [
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589928", what: "", "type": "Analysis",  client: true, status: "Planned", plan: 2, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589928", what: "", "type": "Development",  client: true, status: "Planned", plan: 1, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590199", what: "", "type": "Analysis",  client: true, status: "Planned", plan: 2, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590199", what: "", "type": "Development",  client: true, status: "Planned", plan: 1, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593026", what: "", "type": "Analysis",  client: true, status: "Planned", plan: 2, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590637", what: "", "type": "Development",  client: true, status: "Planned", plan: 1, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5590197", what: "", "type": "Code Review",  client: true, status: "Planned", plan: 0.5, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589502", what: "", "type": "Code Review",  client: true, status: "Planned", plan: 0.5, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5589505", what: "", "type": "Code Review",  client: true, status: "Planned", plan: 0.5, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593556", what: "", "type": "Code Review",  client: true, status: "Planned", plan: 0.5, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593652", what: "", "type": "Code Review",  client: true, status: "Planned", plan: 0.5, totalSpent: 4, "actual": 0 },
  //          { createdOn: new Date(), closedOn: new Date(), id: '', linkID: "US5593680", what: "", "type": "Code Review",  client: true, status: "Planned", plan: 0.5, totalSpent: 4, "actual": 0 }
  //        ], activities: [], futureActivities: []
  //      }],
  //  };

  project: any;
  progress: number = 0;
  sprintKey: string = '';
  projects: Project[] = [];
  selectedProject?: Project;
  sprints: sprint[] = [];


  constructor(private scrumService: ScrumService, private projectService: ProjectService) {


    projectService.getProjects().subscribe((data: Project[]) => {      
      this.projects = data;
      this.selectedProject = this.projects[0];
      this.sprints = this.selectedProject.sprints;

      //scrumService.getScrumDataBySprintNumber('essette', 6).subscribe((data1: any) => {
      //  this.project = data1
      //});
      //console.log(this.sprints[0].startson.toISOString());
      console.log(this.projects[0].sprints[0]);
      console.log(this.sprints[0].key);
      scrumService.getScrumDataBySprintKey(this.selectedProject?.projectKey || '', this.sprints[0].key).subscribe((data: Project) => {
        console.log(data);
        this.project = data;
        let total = (new Date(this.project.endsOn).getTime() - new Date(this.project.startsOn).getTime()) / (1000 * 3600 * 24);
        let elapsed = (new Date(this.project.endsOn).getTime() - new Date().getTime()) / (1000 * 3600 * 24);
        this.progress = Math.ceil((((total - elapsed) / total) * 100));
      });
    });

    //scrumService.getScrumData('essette', new Date(2023,2,29).toISOString().replace(/T.*$/, '')).subscribe((data: Project) => {
    //  console.log(data);
    //  this.project = data;
    //  let total = (new Date(this.project.endsOn).getTime() - new Date(this.project.startsOn).getTime()) / (1000 * 3600 * 24);
    //  let elapsed = (new Date(this.project.endsOn).getTime() - new Date().getTime()) / (1000 * 3600 * 24);
    //  this.progress = Math.ceil((((total - elapsed) / total) * 100));
    //});

  }

  ngOnInit(): void {



  }

  projectChanged(event: any) {
    console.log(event);
  }

  sprintChanged(event: any) {
    console.log(event);
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

  pendingActivities(activity: Activity): boolean {
    return activity.status !== 'Completed';
  }

  closeDay(user: User) {

    let pendingActivities = user.yesterdayActivities.filter(this.pendingActivities)

    pendingActivities.forEach(function (value) {
      user.activities.splice(0, 0, value);
    });

    //remove the not completed items from yesterday's activites 
    for (let i = user.yesterdayActivities.length - 1; i > -1; i--) {
      if (user.yesterdayActivities[i].status !== 'Completed') {
        user.yesterdayActivities.splice(i, 1);
      }
    }


  }

  effort(activities: Activity[]): number {
    let total: number = 0;
    var sumNumber = activities.reduce((acc, cur) => acc + Number(cur.actual), 0)
    //for (let i = 0; i < activities.length; i++) {
    //  let value: number = activities[i]?.actual?.valueOf()||0;
    //  total = total + value;
    //  console.log(total);
    //}
    return sumNumber;
  }

  addTask(activity: Activity, activities: Activity[]) {
    activities.push(activity)
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
