import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Project } from '../../components/dashboard/dashboard.component';

@Injectable({
  providedIn: 'root'
})
export class ScrumService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  getScrumData(projectKey:string, currentDate: any): Observable<Project> {
    return this.http.get<Project>(this.baseUrl + 'scrum/?projectKey='+ projectKey + '&&currentDate=' + currentDate);
  }
  getScrumDataBySprintNumber(projectKey: string, sprintNumber: number): Observable<Project> {
    return this.http.get<Project>(this.baseUrl + 'scrum/getsprint/?projectKey=' + projectKey + '&&sprintNumber=' + sprintNumber);
  }
  //GetSprintByKey
  getScrumDataBySprintKey(projectKey: string, sprintNumber: string): Observable<Project> {
    return this.http.get<Project>(this.baseUrl + 'scrum/getsprintbykey/?projectKey=' + projectKey + '&&sprintKey=' + sprintNumber);
  }
}
