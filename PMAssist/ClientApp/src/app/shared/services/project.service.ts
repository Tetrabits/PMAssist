import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Project } from '../../components/dashboard/dashboard.component';

export interface EffortCategory {
  id: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  getSprintKey(projectKey: string, currentDate: any): Observable<EffortCategory> {
    return this.http.get<EffortCategory>(this.baseUrl + 'project/getscrumkey?projectKey=' + projectKey + '&&currentDate=' + currentDate);
  }
}
