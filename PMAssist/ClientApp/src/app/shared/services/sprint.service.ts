import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SprintActivity } from '../../model/sprintactivity';

@Injectable({
  providedIn: 'root'
})
export class SprintService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  getStories(sprintKey: string): Observable<void> {
    return this.http.get<any>(this.baseUrl + 'sprint/' + sprintKey);
  }

  addActivity(sprintData: SprintActivity): Observable<void> {
    return this.http.post<any>(this.baseUrl + 'sprint/addactivity', sprintData);
  }
}
