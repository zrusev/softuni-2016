import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import { MoviesComponent } from './movies/movies.component';

const routes: Routes = [{
  path: '',
  pathMatch: 'full',
  redirectTo: 'movies'
}, {
  path: 'movies',
  component: MoviesComponent
}, {
  path: 'movies/:id',
  component: MovieDetailsComponent
}];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
