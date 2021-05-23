import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';

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
}
