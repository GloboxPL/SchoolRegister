import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { NewClassDto } from '../models/NewClassDto';
import { NewLessonDto } from '../models/NewLessonDto';
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
  classes: string[] = [];

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
          this.getClasses();
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
    this.getStartData();
    this.router.navigateByUrl('success');
  }

  getTeachers(): void {
    this.http.getTeachers().subscribe(value => this.teachers = value);
  }

  getStudentsWithoutClass(): void {
    this.http.getStudentsWithoutClass().subscribe(value => this.studentsWithoutClass = value);
  }

  addNewClass(newClass: NewClassDto): void {
    this.http.addNewClass(newClass);
    this.getStartData();
    this.router.navigateByUrl('success');
  }

  getClasses(): void {
    this.http.getClasses().subscribe(value => {
      this.classes = value;
    });
  }

  addNewLesson(newLesson: NewLessonDto): void {
    this.http.addNewLesson(newLesson);
    this.router.navigateByUrl('success');
  }
}
