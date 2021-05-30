import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from './services/data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private router: Router, public data: DataService) {
    if (data.user === undefined) {
      this.router.navigateByUrl('');
    }
  }

  navAddUsers(): void {
    this.router.navigateByUrl('add-users');
  }

  navCreateClass(): void {
    this.router.navigateByUrl('create-class');
  }

  navAddLesson(): void {
    this.router.navigateByUrl('add-lesson');
  }

  navTimetable(): void {
    this.router.navigateByUrl('timetable');
  }

  navMarksAndFrequency(): void {
    this.router.navigateByUrl('marks-frequency');
  }

  logOut(): void {
    this.data.logOut();
    this.router.navigateByUrl('');
  }

}
