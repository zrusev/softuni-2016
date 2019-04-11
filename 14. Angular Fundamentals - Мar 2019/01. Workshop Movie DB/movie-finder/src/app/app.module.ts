import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LandingComponent } from './landing/landing.component';
import { MoviesComponent } from './movies/movies.component';
import { MoviesService } from './service/movies.service';
import { HttpClientModule  } from '@angular/common/http';
import { MovieComponent } from './movie/movie.component';
import { FooterComponent } from './footer/footer.component';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import { SingleMovieResolver } from './service/resolvers/single-movie.resolver';
import { FormsModule } from '@angular/forms';
import { MovieSerachComponent } from './movie-serach/movie-serach.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LandingComponent,
    MoviesComponent,
    MovieComponent,
    FooterComponent,
    MovieDetailsComponent,
    MovieSerachComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [MoviesService, SingleMovieResolver],
  bootstrap: [AppComponent]
})
export class AppModule { }
