import { LoginComponent } from './components/login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSubjectComponent } from './components/add-subject/add-subject.component';
import { AddUsersViewComponent } from './components/add-users-view/add-users-view.component';
import { TimetableViewComponent } from './components/timetable-view/timetable-view.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'add-users', component: AddUsersViewComponent },
  { path: 'timetable', component: TimetableViewComponent },
  { path: 'classes', component: LoginComponent },
  { path: 'subjects', component: AddSubjectComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
