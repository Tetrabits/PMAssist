import { Component, OnInit } from '@angular/core';
import { Activity } from '../../model/activity';
import { ScrumService } from '../../shared/services/scrum.service';
import { ProjectService } from '../../shared/services/project.service';
import { UserService } from '../../shared/services/user.service';
import { SprintService } from '../../shared/services/sprint.service';


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

export interface EffortCategory {
  id: number;
  name: string;

}

export interface PlanActivity {
  type?: string;
  user?: string;
  what?: string;
  link?: string;
  plan?: number;
}

interface TaskType {
  value: string;
  name: string;
}

interface UserModel {
  name: string;
  status: string;
  uid: string;
}

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  project: any;
  progress: number = 0;
  sprintKey: string = '';
  projects: Project[] = [];
  selectedProject?: Project;
  sprints: sprint[] = [];
  selectedSprintNumber: number = 0;
  stories: any;
  planActivity: PlanActivity = {};

  planType: TaskType[] = [{
    name: "Activity", value: "Activity"
  },
  { name: "Story", value: "Story" },
  { name: "Bug", value: "Bug" }
  ]
  constructor(private scrumService: ScrumService, private projectService: ProjectService, private sprintService: SprintService) {

  users: UserModel[] = [];


    projectService.getProjects().subscribe((data: Project[]) => {

      let today = new Date();
      let currentSprint = data[0].sprints.find(n => n.startsOn <= today && today <= n.endsOn)

      if (currentSprint === undefined) {
        currentSprint = data[0].sprints[data[0].sprints.length - 1]
      }

      this.projects = data;
      this.selectedProject = this.projects[0];
      this.sprints = this.selectedProject.sprints;
      this.selectedSprintNumber = currentSprint.number;
      console.log(this.selectedSprintNumber);

      let sprintKey = currentSprint?.key || '';

      console.log(sprintKey);
      sprintService.getStories(sprintKey).subscribe((data: any) =>
      {
        console.log(data);
        this.stories = data;
      });

      scrumService.getScrumDataBySprintKey(this.selectedProject?.projectKey || '', sprintKey).subscribe((data: Project) => {
        
        this.project = data;
        let total = (new Date(this.project.endsOn).getTime() - new Date(this.project.startsOn).getTime()) / (1000 * 3600 * 24);
        let elapsed = (new Date(this.project.endsOn).getTime() - new Date().getTime()) / (1000 * 3600 * 24);
        let progress = Math.ceil((((total - elapsed) / total) * 100));
        if (progress > 99) {
          progress = 100;
        }
        this.progress = progress;
                
      });
    });

  }

  ngOnInit(): void {

  }
  handleErrors(error: any) {
    console.log(error);
  }
  projectChanged(event: any) {
    console.log(event);
  }

  sprintChanged(event: any) {
    
    this.sprintService.getStories(event.value.key).subscribe((data: any) => {
      console.log(data);
      this.stories = data;
    });

    this.scrumService.getScrumDataBySprintKey(this.selectedProject?.projectKey || '', event.value.key).subscribe((data: Project) => {
      console.log(data);
      this.project = data;
      let total = (new Date(this.project.endsOn).getTime() - new Date(this.project.startsOn).getTime()) / (1000 * 3600 * 24);
      let elapsed = (new Date(this.project.endsOn).getTime() - new Date().getTime()) / (1000 * 3600 * 24);
      let progress = Math.ceil((((total - elapsed) / total) * 100));
      if (progress > 99) {
        progress = 100;
      }
      this.progress = progress;
    });
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
