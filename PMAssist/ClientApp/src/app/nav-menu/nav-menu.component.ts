import { Component, Inject } from '@angular/core';
import { AuthService } from "../shared/services/auth.service";
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isLoggedIn = false;
    handleUpdateResponse: any;
  constructor(
    public authService: AuthService,
    public router: Router,
    private http: HttpClient, @Inject('BASE_URL') private baseUrl: string
  ) {
    this.isLoggedIn = authService.loggedIn;
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  onLogin() {
    this.authService.GoogleAuth().then(() => {
      localStorage.getItem('user');
      let user = JSON.parse(localStorage.getItem('user')!);

      //this.http.get<string>(this.baseUrl + 'authorize?uid=' + user.uid + '&token=' + user.token)
      //  .subscribe(result => {
      //    console.log(result);
      //  }, error => {
      //    console.log(user);
      //    console.error(error)
      //  });


      this.http.get<string>(this.baseUrl + 'authorize?uid=' + user.uid + '&token=' + user.token)
        .subscribe({
          next: this.handleUpdateResponse.bind(this),
          error: this.handleError.bind(this)
        })
      this.router.navigate(['leave-calendar']);
      this.isLoggedIn = true;
    })
  }

  onLogout() {
    this.authService.SignOut().then(() => {
      this.isLoggedIn = false;
      this.router.navigate(['']);
    })
  }

}
