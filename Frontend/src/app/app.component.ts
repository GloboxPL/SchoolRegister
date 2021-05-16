import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private router: Router) {}

  navUsers(): void {
    this.router.navigateByUrl('users');
  }

  navClasses(): void {
    this.router.navigateByUrl('classes');
  }

  navSubjects(): void {
    this.router.navigateByUrl('subjects');
  }

  logOut(): void {
    this.router.navigateByUrl('');
  }

}
