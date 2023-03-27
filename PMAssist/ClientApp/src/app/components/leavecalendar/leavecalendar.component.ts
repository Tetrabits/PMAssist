import { Component } from '@angular/core';
import { CalendarOptions, DateSelectArg, EventClickArg, EventApi, EventInput } from '@fullcalendar/core';
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

  calenderData: any[] = [];
  loggedUser: any;
  calendarVisible = true;
  disabled: boolean = true;
  displayResponsive: boolean = false;
  startDate: any;
  actualEndDate: any;
  endDate: any;
  description: any;
  isAllDay: boolean = false;
  calendarOptions: CalendarOptions = {};
  calendarApi: any;
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
      initialEvents: this.calenderData, //INITIAL_EVENTS, // alternatively, use the `events` setting to fetch from a feed
      weekends: true,
      editable: true,
      selectable: true,
      selectMirror: true,
      dayMaxEvents: true,
      select: this.handleDateSelect.bind(this),
      eventClick: this.handleEventClick.bind(this),
      // eventsSet: this.handleEvents.bind(this),
      dateClick: this.handleEventOnDateChange.bind(this),
      eventChange: this.handleEventOnDateChange.bind(this)
      /* you can update a remote database when these fire:
      eventAdd:
      eventChange:
      eventRemove:
      */
    };
    
    this.calenderService.getLeaves(this.currentDate).
      subscribe((data: EventInput[]) => {
        this.calenderData = data;
        this.calendarOptions.events = this.calenderData;
      });

    this.user = JSON.parse(localStorage.getItem('user')!);

  }

  ngOnInit() {
    this.loggedUser = this.user.uid;
  }

  currentEvents: EventApi[] = [];


  handleCalendarToggle() {
    this.calendarVisible = !this.calendarVisible;
  }

  handleWeekendsToggle() {
    this.calendarOptions.weekends = !this.calendarOptions.weekends
  }

  handleEventOnDateChange(eventDropInfo: any) {

  }

  handleDateSelect(selectInfo: DateSelectArg) {

    //const title = prompt('Please enter a new title for your event');
    this.calendarApi = selectInfo.view.calendar;

    this.calendarApi.unselect(); // clear date selection


    this.startDate = this.datepipe.transform(selectInfo.start, 'yyyy-MM-dd');
    this.actualEndDate = this.datepipe.transform(selectInfo.end, 'yyyy-MM-dd');
    let endDateVal = selectInfo.end.setDate(selectInfo.end.getDate() - 1);
    this.endDate = this.datepipe.transform(endDateVal, 'yyyy-MM-dd');
    this.description = this.user.displayName;
    this.isAllDay = false;
    this.displaySaveButton = true;
    this.displayDeleteButton = false;
    this.displayUpdateButton = false;
    this.displayResponsive = true;
  }

  handleEventClick(clickInfo: EventClickArg) {
    let eventUser = clickInfo.event.id.split('|')[1];
    if (this.loggedUser !== eventUser) {
      return;
    }

    this.startDate = this.datepipe.transform(clickInfo.event.start, 'yyyy-MM-dd');
    this.actualEndDate = this.datepipe.transform(clickInfo.event.end, 'yyyy-MM-dd');
    let endDateVal = clickInfo?.event?.end?.setDate(clickInfo?.event?.end?.getDate() - 1);
    this.endDate = this.datepipe.transform(endDateVal, 'yyyy-MM-dd');

    this.description = clickInfo.event.title;
    this.isAllDay = !clickInfo.event.allDay;
    this.displaySaveButton = false;
    this.displayUpdateButton = false;
    this.displayDeleteButton = true;
    this.displayResponsive = true;
    // if (confirm(`Are you sure you want to delete the event '${clickInfo.event.title}'`)) {
    //   clickInfo.event.remove();
    // }
  }

  //handleEvents(events: EventApi[]) {
  //  const calendarApi = this.calendarComponent?.getApi();
  //  if (calendarApi && calendarApi.view.type === 'dayGridMonth') {
  //    const selectedDate = calendarApi?.getDate();
  //    this.currentDate = this.datepipe.transform(selectedDate, 'yyyy-MM-dd');
  //    console.log(this.currentDate);
  //    this.calenderService.getCalenderData(this.currentDate).
  //      subscribe((data: EventInput[]) => {
  //        this.calenderData = data;
  //        this.calendarOptions.events = this.calenderData;
  //      });
  //  }

  //  this.currentEvents = events;
  //  this.changeDetector.detectChanges();
  //}

  saveLeaveInfo() {
    let maxValue = this.calenderData.reduce((acc, value) => {
      return (acc = acc > Number(value.id) ? acc : Number(value.id));
    }, 0);
    let nextId = this.createEventId(maxValue);
    this.calenderData.push({
      allDay: !this.isAllDay,
      allow: null,
      borderColor: 'blue',
      classNames: null,
      constraint: null,
      display: null,
      durationEditable: false,
      end: this.endDate,
      endStr: this.endDate,
      extendedProps: { startStr: this.startDate, endStr: this.endDate },
      groupId: null,
      id: nextId,
      overlap: false,
      source: { id: this.loggedUser, url: null, format: null },
      start: this.startDate,
      startEditable: false,
      startStr: this.startDate,
      textColor: null,
      title: this.description,
      url: ''
    });
    this.calendarOptions.events = this.calenderData;
    if (this.description) {
      this.calendarApi.addEvent({
        id: nextId,
        title: this.description,
        start: this.startDate,
        end: this.actualEndDate,
        allDay: !this.isAllDay,
        extendedProps: { startStr: this.startDate, endStr: this.endDate },
        source: { id: this.loggedUser, url: '', format: null, startStr: this.startDate, endStr: this.endDate }
      });
    }
    this.displayResponsive = false;

    this.calenderService.addEvent({
      UID: this.user.uid,
      Start: this.startDate,
      End: this.endDate,
      IsHalfDay: !this.isAllDay,
      AuthToken: this.user.token
    });
  }
  createEventId(eventGuid: number) {
    let id = eventGuid + 1;
    return String(id);
  }

  updateLeaveInfo() {
    this.calenderService.addEvent({
      UID: this.user.uid,
      Start: this.startDate,
      End: this.endDate,
      IsHalfDay: this.isAllDay,
      AuthToken: this.user.token
    });
    this.displayResponsive = false;
  }

  deleteLeaveInfo() {
    let response = this.calenderService.deleteEvent({
      UID: this.user.uid,
      Start: this.startDate,
      End: this.endDate,
      IsHalfDay: this.isAllDay,
      AuthToken: this.user.token,
      CurrentDate: this.currentDate
    }).subscribe(result => {
      this.calenderData = this.calenderData;
      this.calendarOptions.events = this.calenderData;
      console.log(result);
    }, error => console.error(error));
    this.displayResponsive = false;
  }

  allDayEvent(event: any) {
    console.log(event);
    if (!this.displaySaveButton) {
      this.isAllDay = event.checked;
      this.displayUpdateButton = true;
    }
  }
}
