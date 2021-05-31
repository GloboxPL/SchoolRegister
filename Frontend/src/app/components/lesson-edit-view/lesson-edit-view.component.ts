import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserMinDto } from 'src/app/models/UserMinDto';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-lesson-edit-view',
  templateUrl: './lesson-edit-view.component.html',
  styleUrls: ['./lesson-edit-view.component.css']
})
export class LessonEditViewComponent {

  selected: boolean[] = [];
  topicForm: FormGroup;
  markForm: FormGroup;
  isVisible = true;

  constructor(private fb: FormBuilder, public data: DataService) {
    this.markForm = this.fb.group({
      id: -1,
      mark: 5
    });
    this.topicForm = this.fb.group({
      topic: data.editedLesson?.topic
    });
  }

  formatLabel(value: number): number {
    return value;
  }

  save(): void {
    this.isVisible = false;
    const topicL: number = this.topicForm.controls.topic.value;
    //frequency check
    //wyslij
  }

  addMark(): void {
    // tslint:disable-next-line:radix
    const idL: number = parseInt(this.markForm.controls.id.value as string);
    // tslint:disable-next-line:radix
    const markL: number = parseInt(this.markForm.controls.mark.value as string);
    //wyslij
    this.markForm.reset();
  }
}
