import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NewLessonDto } from 'src/app/models/NewLessonDto';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-add-lesson-view',
  templateUrl: './add-lesson-view.component.html',
  styleUrls: ['./add-lesson-view.component.css']
})
export class AddLessonViewComponent {

  subjects: string[] = ['English', 'Art', 'Physics', 'History', 'Information Technology', 'Chemistry', 'Biology', 'Maths', 'PE'];
  days: string[] = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday'];
  addLessonForm: FormGroup;

  constructor(private fb: FormBuilder, public data: DataService) {
    this.addLessonForm = this.fb.group({
      name: '',
      teacherId: -1,
      className: '',
      day: -1,
      lesson: -1
    });
  }

  addLesson(): void {
    if (this.data.studentsWithoutClass === undefined) {
      return;
    }
    const nameL: string = this.addLessonForm.controls.name.value;
    // tslint:disable-next-line:radix
    const teacherIdL: number = parseInt(this.addLessonForm.controls.teacherId.value as string);
    const classNameL: string = this.addLessonForm.controls.className.value;
    // tslint:disable-next-line:radix
    const dayL: number = parseInt(this.addLessonForm.controls.day.value as string);
    // tslint:disable-next-line:radix
    const lessonL: number = parseInt(this.addLessonForm.controls.lesson.value as string);
    const newLesson: NewLessonDto = { name: nameL, teacherId: teacherIdL, className: classNameL, day: dayL, lesson: lessonL };
    this.data.addNewLesson(newLesson);
  }

}
