import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { EventInput, EventApi } from '@fullcalendar/core';

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

  addEvent(event: any):void {
    this.http.post<any>(this.baseUrl + 'leaveinformation/addevent', event)
      .subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }

  deleteEvent(event: any): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'leaveinformation/deleteevent', event);
  }
}
