import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../service/movies.service';
import Movie from 'src/Models/Movie';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie-serach',
  templateUrl: './movie-serach.component.html',
  styleUrls: ['./movie-serach.component.css']
})
export class MovieSerachComponent implements OnInit {
  searchMovies: Movie[];

  constructor(
    private moviesService: MoviesService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    const query = this.route.snapshot.queryParams['search'];
    this.moviesService.searchMovie(query)
      .subscribe((data) => {
        this.searchMovies = data['results'];
      });
  }
}
