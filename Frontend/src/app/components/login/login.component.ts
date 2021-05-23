import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  signInForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private router: Router, private data: DataService) {
    this.signInForm = this.formBuilder.group({
      email: '',
      password: ''
    });
  }

  signIn(): void {
    const email = this.signInForm.controls.email.value;
    const password = this.signInForm.controls.password.value;
    this.data.signIn(email, password);

    this.signInForm.reset();
  }
}
