import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {
  phoneNumbers: string[] = ['+971', '+359', '+972', '+198', '+701'];

  constructor() { }

  ngOnInit() {
  }

  register(value: any) {
    console.log(value);
  }
}
