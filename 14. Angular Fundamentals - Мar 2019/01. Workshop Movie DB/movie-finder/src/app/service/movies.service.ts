import { HttpClient } from '@angular/common/http';
import { Observable } from '../../../node_modules/rxjs';
import Movie from '../../Models/Movie';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

const BASE_URL = 'https://api.themoviedb.org/3/movie';
const IN_THEATER = 'https://api.themoviedb.org/3/discover/movie';
const API_KEY = '?api_key=0290ab7f95ccdca4514a6a26745d9eb1';
const KIDS = '&certification_country=US&certification.lte=G&sort_by=popularity.desc';
const BEST_DRAMA = '&with_genres=18&primary_release_year=2019';

@Injectable({
  providedIn: 'root'
})

export class MoviesService {

  constructor(private http: HttpClient) { }

  getPopularMovies(): Observable<Array<Movie>> {
    return this.http.get<Movie[]>(BASE_URL + '/popular' + API_KEY)
      .pipe(
        map((data) => data['results'].slice(0, 6))
      );
  }

  getInTheaterMovies(): Observable<Array<Movie>> {
    return this.http.get<Movie[]>(IN_THEATER + API_KEY + '&with_release_type=2|3')
      .pipe(
        map((data) => data['results'].slice(0, 6))
      );
  }

  getPopularKidsMovies() {
    return this.http.get<Movie[]>(IN_THEATER + API_KEY + KIDS)
      .pipe(
        map((data) => data['results'].slice(0, 6))
      );
  }

  getBestDramaMovies() {
    return this.http.get<Movie[]>(IN_THEATER + API_KEY + BEST_DRAMA)
    .pipe(
      map((data) => data['results'].slice(0, 6))
    );
  }
}