import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';
import { UserMinDto } from '../models/UserMinDto';
import { NewClassDto } from '../models/NewClassDto';
import { NewLessonDto } from '../models/NewLessonDto';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private readonly PATH = 'https://localhost:5001/';
  private headers = new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Credentials': 'true'
  });
  private options = { headers: this.headers, withCredentials: true };

  constructor(private http: HttpClient) { }

  signIn(emailIn: string, passwordIn: string): Observable<User> {
    const body = ({
      email: emailIn,
      password: passwordIn
    });
    return this.http.post<User>(this.PATH + 'login', body, this.options);
  }

  logOut(): void {
    this.http.post(this.PATH + 'logout', null, this.options).subscribe(value => { });
  }

  addNewUsers(users: User[]): void {
    this.http.post(this.PATH + 'user/create', users, this.options).subscribe(value => { });
  }

  getTeachers(): Observable<UserMinDto[]> {
    return this.http.get<UserMinDto[]>(this.PATH + 'user/teachers-list', this.options);
  }

  getStudentsWithoutClass(): Observable<UserMinDto[]> {
    return this.http.get<UserMinDto[]>(this.PATH + 'user/students-no-class', this.options);
  }

  addNewClass(newClass: NewClassDto): void {
    this.http.post(this.PATH + 'create-class', newClass, this.options).subscribe(value => { });
  }

  getClasses(): Observable<string[]> {
    return this.http.get<string[]>(this.PATH + 'classes-list', this.options);
  }

  addNewLesson(newLesson: NewLessonDto): void {
    this.http.post(this.PATH + 'add-lesson', newLesson, this.options).subscribe(value => { });
  }
}
