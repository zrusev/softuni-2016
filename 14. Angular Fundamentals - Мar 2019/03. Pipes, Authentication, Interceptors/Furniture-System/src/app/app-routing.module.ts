import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Components
import { AuthGuard } from './authentication/guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { SigninComponent } from './authentication/signin/signin.component';
import { SignupComponent } from './authentication/signup/signup.component';
import { CreateFurnitureComponent } from './furniture/create-furniture/create-furniture.component';
import { FurnitureAllComponent } from './furniture/furniture-all/furniture-all.component';
import { FurnitureDetailsComponent } from './furniture/furniture-details/furniture-details.component';
import { FurnitureUserComponent } from './furniture/furniture-user/furniture-user.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: 'home', component: HomeComponent },
  { path: 'signin', component: SigninComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'furniture/create', component: CreateFurnitureComponent },
  { path: 'furniture/all', component: FurnitureAllComponent },
  { path: 'furniture/details/:id', component: FurnitureDetailsComponent },
  { path: 'furniture/user', component: FurnitureUserComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }