import { LoginComponent } from './components/login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddUsersComponent } from './components/add-users/add-users.component';
import { AddSubjectComponent } from './components/add-subject/add-subject.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'users', component: AddUsersComponent },
  { path: 'classes', component: LoginComponent },
  { path: 'subjects', component: AddSubjectComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
