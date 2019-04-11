import { HttpClient } from '@angular/common/http';
import { Observable } from '../../../node_modules/rxjs';
import Movie from '../../Models/Movie';
import { Injectable } from '@angular/core';

const BASE_URL = 'https://api.themoviedb.org/3/movie';
const IN_THEATER = 'https://api.themoviedb.org/3/discover/movie';
const API_KEY = '?api_key=';

@Injectable({
  providedIn: 'root'
})

export class MoviesService {

  constructor(private http: HttpClient) { }

  getPopularMovies(): Observable<Array<Movie>> {
    return this.http.get<Array<Movie>>(BASE_URL + '/popular' + API_KEY);
  }

  getInTheaterMovies(): Observable<Array<Movie>> {
    return this.http.get<Array<Movie>>(IN_THEATER + API_KEY + '&with_release_type=2|3');
  }
}