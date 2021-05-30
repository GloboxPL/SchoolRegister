import { LoginComponent } from './components/login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddUsersViewComponent } from './components/add-users-view/add-users-view.component';
import { TimetableViewComponent } from './components/timetable-view/timetable-view.component';
import { CreateClassViewComponent } from './components/create-class-view/create-class-view.component';
import { AddLessonViewComponent } from './components/add-lesson-view/add-lesson-view.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'add-users', component: AddUsersViewComponent },
  { path: 'timetable', component: TimetableViewComponent },
  { path: 'create-class', component: CreateClassViewComponent },
  { path: 'add-lesson', component: AddLessonViewComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
