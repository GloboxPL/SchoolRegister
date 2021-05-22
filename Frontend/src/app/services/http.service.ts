import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private readonly PATH = 'http://localhost:5000/';

  constructor(private http: HttpClient) { }

  signIn(emailIn: string, passwordIn: string): Observable<User> {
    const body = ({
      email: emailIn,
      password: passwordIn
    });
    return this.http.post<User>(this.PATH + 'login', body);
  }

  logOut(): void {
    this.http.post(this.PATH + 'logout', null);
  }
}
