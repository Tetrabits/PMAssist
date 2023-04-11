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

  getScrumData(currentDate: any): Observable<Project> {
    return this.http.get<Project>(this.baseUrl + 'scrum/?currentDate=' + currentDate);
  }
}
