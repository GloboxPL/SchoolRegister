import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/User';
import { UserMinDto } from 'src/app/models/UserMinDto';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-create-class-view',
  templateUrl: './create-class-view.component.html',
  styleUrls: ['./create-class-view.component.css']
})
export class CreateClassViewComponent implements OnInit {

  constructor(public data: DataService) { }

  ngOnInit(): void {
  }

}
