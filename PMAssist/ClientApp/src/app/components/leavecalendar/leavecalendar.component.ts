import { Component, ChangeDetectorRef, ViewChild, ElementRef, Inject } from '@angular/core';
import { CalendarOptions, DateSelectArg, EventClickArg, EventApi, EventInput, Calendar, EventDropArg } from '@fullcalendar/core';
import interactionPlugin from '@fullcalendar/interaction';
import { FullCalendarComponent } from "@fullcalendar/angular";
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import listPlugin from '@fullcalendar/list';
import { DatePipe } from '@angular/common'
import { CalenderService } from '../../shared/services/calender.service';

@Component({
  selector: 'app-calendar',
  templateUrl: './leavecalendar.component.html',
  styleUrls: ['./leavecalendar.component.css']
})
export class LeaveCalendarComponent {
  @ViewChild('calendar') calendarComponent: FullCalendarComponent = new FullCalendarComponent(this.element, this.changeDetector); // the
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
  apiBaseUrl: string = "";
  user: any;

  constructor(private changeDetector: ChangeDetectorRef, public datepipe: DatePipe,
    private calenderService: CalenderService, private element: ElementRef<any>, @Inject('BASE_URL') baseUrl: string) {
    this.apiBaseUrl = baseUrl;
    this.calendarOptions = {
      plugins: [
        interactionPlugin,
        dayGridPlugin,
        timeGridPlugin,
        listPlugin,
      ],
      headerToolbar: {
        left: 'prev,next today',
        center: 'title',
        right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
      },
      initialView: 'dayGridMonth',
      initialEvents: this.calenderData, //INITIAL_EVENTS, // alternatively, use the `events` setting to fetch from a feed
      weekends: true,
      editable: true,
      selectable: true,
      selectMirror: true,
      dayMaxEvents: true,
      select: this.handleDateSelect.bind(this),
      eventClick: this.handleEventClick.bind(this),
      //eventsSet: this.handleEvents.bind(this),
      dateClick: this.handleEventOnDateChange.bind(this),
      eventChange: this.handleEventOnDateChange.bind(this)
      /* you can update a remote database when these fire:
      eventAdd:
      eventChange:
      eventRemove:
      */
    };
    this.calenderService.getCalenderData(this.currentDate, baseUrl).
      subscribe((data: EventInput[]) => {
        this.calenderData = data;
        this.calendarOptions.events = this.calenderData;
      });

    this.user = JSON.parse(localStorage.getItem('user')!);
    console.log(this.user);
  }


  ngOnInit() {
    this.loggedUser = this.user.uid;
    console.log(this.currentEvents);
  }


  currentEvents: EventApi[] = [];

  ngAfterViewInit() {

  }
  handleDatesRender($event: any) {
    console.log($event);
  }



  handleCalendarToggle() {
    this.calendarVisible = !this.calendarVisible;
  }

  handleWeekendsToggle() {
    this.calendarOptions.weekends = !this.calendarOptions.weekends
  }

  handleEventOnDateChange(eventDropInfo: any) {
    console.log(eventDropInfo);
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
    this.isAllDay = selectInfo.allDay;
    this.displayResponsive = true;
  }

  handleEventClick(clickInfo: EventClickArg) {
    let eventUser = clickInfo.event.extendedProps['source'].id;
    if (this.loggedUser !== eventUser) {
      return;
    }
    let props = clickInfo.event.extendedProps;
    this.startDate = clickInfo.event.extendedProps['startStr'];//this.datepipe.transform(clickInfo.event.start, 'yyyy-MM-dd');
    let endDateVal = clickInfo?.event?.end?.setDate(clickInfo.event.end.getDate() - 1);
    this.endDate = clickInfo.event.extendedProps['endStr'];//this.datepipe.transform(clickInfo.event.end, 'yyyy-MM-dd');
    this.description = clickInfo.event.title;
    this.displayResponsive = true;
    // if (confirm(`Are you sure you want to delete the event '${clickInfo.event.title}'`)) {
    //   clickInfo.event.remove();
    // }
  }

  handleEvents(events: EventApi[]) {
    const calendarApi = this.calendarComponent?.getApi();
    if (calendarApi && calendarApi.view.type === 'dayGridMonth') {
      const selectedDate = calendarApi?.getDate();
      this.currentDate = this.datepipe.transform(selectedDate, 'yyyy-MM-dd');
      console.log(this.currentDate);
      this.calenderService.getCalenderData(this.currentDate, this.apiBaseUrl).
        subscribe((data: EventInput[]) => {
          this.calenderData = data;
          this.calendarOptions.events = this.calenderData;
        });
    }

    this.currentEvents = events;
    this.changeDetector.detectChanges();
  }

  saveLeaveInfo() {
    console.log("save event");
    let maxValue = this.calenderData.reduce((acc, value) => {
      return (acc = acc > Number(value.id) ? acc : Number(value.id));
    }, 0);
    let nextId = this.createEventId(maxValue);
    this.calenderData.push({
      allDay: this.isAllDay,
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
        allDay: this.isAllDay,
        extendedProps: { startStr: this.startDate, endStr: this.endDate },
        source: { id: this.loggedUser, url: null, format: null },
        backgroundColor: "green"
      });
    }
    this.displayResponsive = false;
    console.log(this.loggedUser);
   
    this.calenderService.addEvent({
      UID: this.user.uid,
      Start: this.startDate,
      End: this.endDate,
      IsHalfDay: this.isAllDay,
      AuthToken: this.user.token
    });
  }
  createEventId(eventGuid: number) {
    let id = eventGuid + 1;
    return String(id);
  }
}
