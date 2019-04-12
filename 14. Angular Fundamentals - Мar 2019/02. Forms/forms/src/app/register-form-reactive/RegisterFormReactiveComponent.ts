import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-form-reactive',
  templateUrl: './register-form-reactive.component.html',
  styleUrls: ['./register-form-reactive.component.css']
})

export class RegisterFormReactiveComponent implements OnInit {
  form: any;

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.form = this.fb.group({
      fullName: ['', [Validators.required, Validators.pattern(/[A-Z][a-z]+\s[A-Z][a-z]+/)]],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  register() {
  }

  get f() {
      return this.form.controls;
  }
}
