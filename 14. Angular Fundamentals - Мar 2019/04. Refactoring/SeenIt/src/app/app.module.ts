import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { PostListComponent } from './components/post/post-list/post-list.component';
import { PostCreateComponent } from './components/post/post-create/post-create.component';
import { PostEditComponent } from './components/post/post-edit/post-edit.component';
import { PostDetailsComponent } from './components/post/post-details/post-details.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { ContentComponent } from './components/shared/content/content.component';
import { PostInfoComponent } from './components/post/post-info/post-info.component';
import { CommentInfoComponent } from './components/comment/comment-info/comment-info.component';
import { CommentCreateComponent } from './components/comment/comment-create/comment-create.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    PostListComponent,
    PostCreateComponent,
    PostEditComponent,
    PostDetailsComponent,
    HeaderComponent,
    FooterComponent,
    ContentComponent,
    PostInfoComponent,
    CommentInfoComponent,
    CommentCreateComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [
  
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
