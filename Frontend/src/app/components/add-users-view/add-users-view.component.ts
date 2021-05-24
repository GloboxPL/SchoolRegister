import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Role } from 'src/app/models/Role';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-add-users-view',
  templateUrl: './add-users-view.component.html',
  styleUrls: ['./add-users-view.component.css']
})
export class AddUsersViewComponent implements OnInit {

  count = 1;
  addUserForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private router: Router, private data: DataService) {
    this.addUserForm = this.formBuilder.group({
      emails: '',
      names: '',
      surnames: '',
      roles: Role.None
    });
  }

  ngOnInit(): void {
  }

  addUsers() {

  }
}
