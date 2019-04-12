import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {
  phoneNumbers: string[] = ['+971', '+359', '+972', '+198', '+701'];

  @ViewChild('form')
  htmlForm: NgForm;

  constructor() { }

  ngOnInit() {
  }

  register(form: NgForm) {
    if (!this.htmlForm.invalid) {
      this.htmlForm.reset();
    }
  }
}
