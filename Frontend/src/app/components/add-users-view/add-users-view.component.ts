import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Role } from 'src/app/models/Role';
import { User } from 'src/app/models/User';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-add-users-view',
  templateUrl: './add-users-view.component.html',
  styleUrls: ['./add-users-view.component.css']
})
export class AddUsersViewComponent {

  addUserForm: FormGroup;
  usersArray: any[] = [];
  isError = false;
  isSuccess = false;
  private users = new Array<User>();

  constructor(private fb: FormBuilder, private router: Router, private data: DataService) {
    this.addUserForm = this.createForm();
  }

  createForm(): FormGroup {
    return this.fb.group({
      users: this.fb.array(this.usersArray)
    });
  }

  pushNewElement(): void {
    this.isSuccess = false;
    if (this.usersArray.length >= 10) {
      return;
    }
    this.usersArray.push(this.buildFormDynamic());
    this.addUserForm = this.createForm();
  }

  popLastElement(): void {
    this.isSuccess = false;
    if (this.usersArray.length < 1) {
      return;
    }
    this.usersArray.pop();
    this.addUserForm = this.fb.group({
      users: this.fb.array(this.usersArray)
    });
  }

  buildFormDynamic(): FormGroup {
    return this.fb.group({
      name: '',
      surname: '',
      email: '',
      role: null
    });
  }

  readForm(): void {
    this.addUserForm.value.users.forEach((item: { name: string; surname: string; email: string; role: string; }) => {
      let fRole: Role;
      switch (item.role) {
        case '0':
          fRole = Role.Student;
          break;
        case '1':
          fRole = Role.Parent;
          break;
        case '2':
          fRole = Role.Teacher;
          break;
        case '4':
          fRole = Role.Admin;
          break;
        default:
          this.isError = true;
          this.isSuccess = false;
          return;
      }
      if (item.name.length < 2 || item.surname.length < 2 || item.email.length < 6) {
        this.isError = true;
        this.isSuccess = false;
        this.users = [];
        return;
      }
      const user: User = { id: 0, name: item.name, surname: item.surname, email: item.email, role: fRole };
      this.users.push(user);
    });
  }

  SaveData(): void {
    this.readForm();
    this.data.addNewUsers(this.users);
    this.clean();
  }

  getControls(): AbstractControl[] {
    return (this.addUserForm.controls.users as FormArray).controls;
  }

  clean(): void {
    this.isSuccess = true;
    this.addUserForm.reset();
    this.usersArray = [];
    this.addUserForm = this.createForm();
  }
}
