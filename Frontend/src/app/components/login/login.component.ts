import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  signInForm: FormGroup;
  isSignInError = false;

  constructor(private formBuilder: FormBuilder, private router: Router, private data: DataService) {
    this.signInForm = this.formBuilder.group({
      email: '',
      password: ''
    });
  }

  ngOnInit(): void {
    this.data.isSignInError.subscribe(value => this.isSignInError = value);
  }

  signIn(): void {
    const email = this.signInForm.controls.email.value;
    const password = this.signInForm.controls.password.value;
    this.data.signIn(email, password);
  }
}
