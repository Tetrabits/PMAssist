import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { FullCalendarModule } from '@fullcalendar/angular';
import { DialogModule } from 'primeng/dialog';
import { TabViewModule } from 'primeng/tabview';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InputTextModule } from 'primeng/inputtext';
import { CheckboxModule } from 'primeng/checkbox';
import { DatePipe } from '@angular/common';
import interactionPlugin from '@fullcalendar/interaction';
import dayGridPlugin from '@fullcalendar/daygrid';
FullCalendarModule.bind([interactionPlugin, dayGridPlugin]);

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './components/login/login.component';

import { environment } from '../environments/environment';
import { AngularFireModule } from '@angular/fire/compat';

import { AuthService } from "./shared/services/auth.service";
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LogoutComponent } from './components/logout/logout.component';

import { ButtonModule } from 'primeng/button';

import { LeaveCalendarComponent } from './components/leavecalendar/leavecalendar.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    DashboardComponent,
    LogoutComponent,
    LeaveCalendarComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'login', component: LoginComponent },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'logout', component: LogoutComponent },
      {path: 'leave-calendar', component: LeaveCalendarComponent}
    ]),
    AngularFireModule.initializeApp(environment.firebase),
    ButtonModule,
    BrowserAnimationsModule,
    DialogModule,
    TabViewModule,
    InputTextModule,
    CheckboxModule,
    FullCalendarModule
  ],
  providers: [AuthService,DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
