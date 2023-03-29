import { Component } from '@angular/core';
import { CalendarOptions, DateSelectArg, EventClickArg, EventInput } from '@fullcalendar/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';

import { DatePipe } from '@angular/common'
import { CalenderService } from '../../shared/services/calender.service';

@Component({
  selector: 'app-calendar',
  templateUrl: './leavecalendar.component.html',
  styleUrls: ['./leavecalendar.component.css']
})
export class LeaveCalendarComponent {
  txtBoxDisabled: boolean = false;
  loggedUser: any;
  displayDailog: boolean = false;
  startDate: any;
  actualEndDate: any;
  endDate: any;
  description: any;
  isAllDay: boolean = false;
  calendarOptions: CalendarOptions = {};
  currentDate: any = new Date().toISOString().replace(/T.*$/, '');
  user: any;
  displayDeleteButton: boolean = false;
  displayUpdateButton: boolean = false;
  displaySaveButton: boolean = true;


  constructor(private calenderService: CalenderService, public datepipe: DatePipe) {

    this.calendarOptions = {
      plugins: [
        dayGridPlugin,
        interactionPlugin
      ],
      initialView: 'dayGridMonth',
      weekends: true,
      editable: true,
      selectable: true,
      selectMirror: true,
      dayMaxEvents: true,
      select: this.handleDateSelect.bind(this),
      eventClick: this.handleEventClick.bind(this)
    };

    this.calenderService.getLeaves(this.currentDate).
      subscribe((data: EventInput[]) => {
        this.calendarOptions.events = data;
      });

    this.user = JSON.parse(localStorage.getItem('user')!);

  }

  ngOnInit() {
    this.loggedUser = this.user.uid;
  }

  handleDateSelect(selectInfo: DateSelectArg) {
     var calendarApi = selectInfo.view.calendar;

    calendarApi.unselect(); // clear date selection

    this.startDate = this.datepipe.transform(selectInfo.start, 'yyyy-MM-dd');
    this.actualEndDate = this.datepipe.transform(selectInfo.end, 'yyyy-MM-dd');
    let endDateVal = selectInfo.end.setDate(selectInfo.end.getDate() - 1);
    this.endDate = this.datepipe.transform(endDateVal, 'yyyy-MM-dd');
    this.description = this.user.displayName;
    this.isAllDay = false;
    this.displaySaveButton = true;
    this.displayDeleteButton = false;
    this.displayUpdateButton = false;
    this.displayDailog = false;

    this.saveLeaveInfo();
  }

  handleEventClick(clickInfo: EventClickArg) {
    let eventUser = clickInfo.event.id.split('|')[1];
    if (this.loggedUser !== eventUser) {
      return;
    }

    this.startDate = this.datepipe.transform(clickInfo.event.start, 'yyyy-MM-dd');
    this.actualEndDate = this.datepipe.transform(clickInfo.event.end, 'yyyy-MM-dd');
    this.endDate = this.actualEndDate;
    this.description = clickInfo.event.title;
    this.displaySaveButton = false;
    this.displayUpdateButton = false;
    this.displayDeleteButton = true;
    this.displayDailog = true;
  }

  getLeavesInformation() {
    this.calenderService.getLeaves(this.currentDate).
      subscribe((data: EventInput[]) => {
        this.calendarOptions.events = data;
        this.displayDailog = false;
      });
  }

  handleErrors(error: any) {
    console.log(error);
    this.displayDailog = false;
  }

  saveLeaveInfo() {
    this.calenderService.addEvent({
      UID: this.user.uid,
      Start: this.startDate,
      End: this.endDate,
      IsHalfDay: !this.isAllDay,
      AuthToken: this.user.token
    }).subscribe({
      next: this.getLeavesInformation.bind(this),
      error: this.handleErrors.bind(this)
    });
  }

  updateLeaveInfo() {
    this.calenderService.addEvent({
      UID: this.user.uid,
      Start: this.startDate,
      End: this.endDate,
      IsHalfDay: this.isAllDay,
      AuthToken: this.user.token
    }).subscribe({
      next: this.getLeavesInformation.bind(this),
      error: this.handleErrors.bind(this)
    });
  }

  deleteLeaveInfo() {
    this.calenderService.deleteEvent({
      UID: this.user.uid,
      Start: this.startDate,
      End: this.endDate,
      IsHalfDay: this.isAllDay,
      AuthToken: this.user.token,
      CurrentDate: this.currentDate
    }).subscribe({
      next: this.getLeavesInformation.bind(this),
      error: this.handleErrors.bind(this)
    });
  }

  allDayEvent(event: any) {
    console.log(event);
    if (!this.displaySaveButton) {
      this.isAllDay = event.checked;
      this.displayUpdateButton = true;
    }
  }
}
