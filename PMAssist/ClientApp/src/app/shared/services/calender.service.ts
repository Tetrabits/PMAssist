import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { EventInput,EventApi } from '@fullcalendar/core';

@Injectable({
  providedIn: 'root'
})
export class CalenderService {

  private apiUrl = 'http://localhost:42184/leaveinformation';
  currentEvents: EventApi[] = [];

  constructor(
    private http: HttpClient) { }

    getCalenderData(currentDate : any,baseUrl:string): Observable<EventInput[]> {
      return this.http.get<EventInput[]>(baseUrl + 'leaveinformation/?currentDate=' + currentDate)
      .pipe(
        tap()
      );
    }
}
