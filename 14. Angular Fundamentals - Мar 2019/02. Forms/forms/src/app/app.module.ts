import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { ImageUrlVDirective } from './image-url-v.directive';
import { RegisterFormReactiveComponent } from "./register-form-reactive/RegisterFormReactiveComponent";

@NgModule({
  declarations: [
    AppComponent,
    RegisterFormComponent,
    ImageUrlVDirective,
    RegisterFormReactiveComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
