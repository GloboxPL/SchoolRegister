import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NewClassDto } from 'src/app/models/NewClassDto';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-create-class-view',
  templateUrl: './create-class-view.component.html',
  styleUrls: ['./create-class-view.component.css']
})
export class CreateClassViewComponent implements OnInit {

  selected: boolean[] = [];
  classForm: FormGroup;

  constructor(private fb: FormBuilder, public data: DataService) {
    this.classForm = this.fb.group({
      name: '',
      teacherId: -1
    });
  }

  ngOnInit(): void {
    this.data.studentsWithoutClass?.forEach(student => {
      this.selected.push(false);
    });
  }

  addClass(): void {
    if (this.data.studentsWithoutClass === undefined) {
      return;
    }
    const nameL: string = this.classForm.controls.name.value;
    // tslint:disable-next-line:radix
    const teacherIdL: number = parseInt(this.classForm.controls.teacherId.value as string);
    const studentsIdsL: number[] = [];
    for (let i = 0; i < this.selected.length; i++) {
      if (this.selected[i]) {
        studentsIdsL.push(this.data.studentsWithoutClass[i].id);
      }
    }
    const newClass: NewClassDto = { name: nameL, teacherId: teacherIdL, studentsIds: studentsIdsL };
    this.data.addNewClass(newClass);
    this.classForm.reset();
    this.selected = [];
  }

}
