import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { PostListComponent } from './components/post/post-list/post-list.component';
import { PostCreateComponent } from './components/post/post-create/post-create.component';
import { PostEditComponent } from './components/post/post-edit/post-edit.component';
import { PostDetailsComponent } from './components/post/post-details/post-details.component';
import { SinglePostResolver } from './core/resolvers/single-post.resolver';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/login' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'posts', children: [
      { path: '', component: PostListComponent },
      { path: 'user', component: PostListComponent },
      { path: 'create', component: PostCreateComponent },
      { path: 'edit/:id', component: PostEditComponent },
      { path: 'details/:id', component: PostDetailsComponent, resolve: { post: SinglePostResolver } }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
