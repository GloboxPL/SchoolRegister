import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { AddUsersViewComponent } from './components/add-users-view/add-users-view.component';
import {MatCardModule} from '@angular/material/card';
import {MatDividerModule} from '@angular/material/divider';
import { TimetableViewComponent } from './components/timetable-view/timetable-view.component';
import {MatTooltipModule} from '@angular/material/tooltip';
import { CreateClassViewComponent } from './components/create-class-view/create-class-view.component';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatGridListModule} from '@angular/material/grid-list';
import { TimetableComponent } from './components/timetable/timetable.component';
import { AddLessonViewComponent } from './components/add-lesson-view/add-lesson-view.component';
import { SuccessViewComponent } from './components/success-view/success-view.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AddUsersViewComponent,
    TimetableViewComponent,
    CreateClassViewComponent,
    TimetableComponent,
    AddLessonViewComponent,
    SuccessViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatToolbarModule,
    MatButtonModule,
    MatSelectModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule,
    MatCardModule,
    MatDividerModule,
    MatTooltipModule,
    MatCheckboxModule,
    MatGridListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
