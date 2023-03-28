import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { EventInput, EventApi } from '@fullcalendar/core';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class CalenderService {

  currentEvents: EventApi[] = [];

  constructor(
    private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getCalenderData(currentDate: any): Observable<EventInput[]> {
    return this.http.get<EventInput[]>(this.baseUrl + 'leaveinformation/?currentDate=' + currentDate)
      .pipe(
        tap()
      );
  }

  getLeaves(date: Date) {
    let user: User = JSON.parse(localStorage.getItem('user')!);

    let leaveRequestModel = {
      date: date,
      userId: user.uid,
      authToken: user.token
    };

    return this.http.post<EventInput[]>(this.baseUrl + 'leaveinformation/getleaves', leaveRequestModel)
      .pipe(tap());
  }

  addEvent(event: any): Observable<void> {
    return this.http.post<any>(this.baseUrl + 'leaveinformation/addevent', event);
  }

  deleteEvent(event: any): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'leaveinformation/deleteevent', event);
  }
}
