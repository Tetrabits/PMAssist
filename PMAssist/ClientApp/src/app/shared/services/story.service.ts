import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Story } from "../../model/story";

@Injectable({
  providedIn: 'root'
})
export class ScrumService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  addActivity(storyData: Story): Observable<void> {
    return this.http.post<any>(this.baseUrl + 'story/addactivity', storyData);
  }
}
