import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  signInForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private router: Router) {
    this.signInForm = this.formBuilder.group({
      email: '',
      password: ''
    });
  }

  ngOnInit() {
  }

  signIn(): void {
    const signInData = {
      username: this.signInForm.controls['email'].value,
      password: this.signInForm.controls['password'].value
    };
    console.log(signInData.username);

    this.signInForm.reset();
    this.router.navigateByUrl('users');
  }
}
