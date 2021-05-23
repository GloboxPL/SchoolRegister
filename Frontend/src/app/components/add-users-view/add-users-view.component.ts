import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-users-view',
  templateUrl: './add-users-view.component.html',
  styleUrls: ['./add-users-view.component.css']
})
export class AddUsersViewComponent implements OnInit {

  count = 0;
  // newUsers: FormGroup;

  constructor() { }

  ngOnInit(): void {
  }

}
