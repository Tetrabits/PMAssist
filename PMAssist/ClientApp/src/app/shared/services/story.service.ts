import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SprintActivity } from "../../model/sprintactivity";

@Injectable({
  providedIn: 'root'
})
export class ScrumService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  addActivity(storyData: SprintActivity): Observable<void> {
    return this.http.post<any>(this.baseUrl + 'story/addactivity', storyData);
  }
}
