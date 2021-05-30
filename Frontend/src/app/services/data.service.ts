import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { NewClassDto } from '../models/NewClassDto';
import { User } from '../models/User';
import { UserMinDto } from '../models/UserMinDto';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpService, private router: Router) { }

  user: User | undefined;
  isSignInError = new BehaviorSubject<boolean>(false);
  studentsWithoutClass: UserMinDto[] | undefined;
  teachers: UserMinDto[] | undefined;

  signIn(email: string, password: string): void {
    this.http.signIn(email, password).subscribe(value => {
      this.user = value;
      this.isSignInError.next(false);
      this.getStartData();
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

  getStartData(): void {
    if (this.user !== undefined) {
      switch (this.user.role) {
        case 4:
          this.getStudentsWithoutClass();
          this.getTeachers();
          break;
        default:
          break;
      }
    }
  }

  logOut(): void {
    this.http.logOut();
    this.user = undefined;
  }

  addNewUsers(users: User[]): void {
    this.http.addNewUsers(users);
    this.getStudentsWithoutClass();
  }

  getTeachers(): void {
    this.http.getTeachers().subscribe(value => this.teachers = value);
  }

  getStudentsWithoutClass(): void {
    this.http.getStudentsWithoutClass().subscribe(value => this.studentsWithoutClass = value);
  }

  addNewClass(newClass: NewClassDto): void {
    this.http.addNewClass(newClass);
    this.getStudentsWithoutClass();
  }
}
