import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import { MoviesComponent } from './movies/movies.component';
import { SingleMovieResolver } from './service/resolvers/single-movie.resolver';
import { MovieSerachComponent } from './movie-serach/movie-serach.component';

const routes: Routes = [{
  path: '',
  pathMatch: 'full',
  redirectTo: 'movies'
}, {
  path: 'movies/search',
  component: MovieSerachComponent
}, {
  path: 'movies',
  component: MoviesComponent
}, {
  path: 'movies/:id',
  component: MovieDetailsComponent,
  resolve: { singleMovie: SingleMovieResolver }
}];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
