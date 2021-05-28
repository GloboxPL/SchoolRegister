import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { Role } from '../models/Role';
import { User } from '../models/User';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpService, private router: Router) { }

  user: User = this.guestUser();
  isSignInError = new BehaviorSubject<boolean>(false);

  signIn(email: string, password: string): void {
    this.http.signIn(email, password).subscribe(value => {
      this.user = value;
      this.isSignInError.next(false);
      if (this.user.role === 4) {
        this.router.navigateByUrl('add-users');
      }
      else {
        this.router.navigateByUrl('timetable');
      }
    }, e => {
      console.log(e);
      this.isSignInError.next(true);
    });
  }

  logOut(): void {
    this.http.logOut();
    this.user = this.guestUser();
  }

  guestUser(): User {
    const user: User = ({
      id: -1,
      name: 'guest',
      surname: 'guest',
      email: 'email',
      role: Role.None
    });
    return user;
  }
}
