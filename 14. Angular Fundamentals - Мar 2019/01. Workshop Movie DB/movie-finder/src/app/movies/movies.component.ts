import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../service/movies.service';
import Movie from 'src/Models/Movie';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  popularMovies: Array<Movie>;
  inTheaterMovies: Array<Movie>;
  message: string = null;

  constructor(private moviesService: MoviesService) { }

  ngOnInit() {
    this.moviesService.getPopularMovies().subscribe(data => {
      this.popularMovies = data['results'].slice(0, 6);
    });

    this.moviesService.getInTheaterMovies().subscribe(data => {
      this.inTheaterMovies = data['results'].slice(6, 12);
    });
  }

  fromChild(event) {
    this.message = 'Button with id: '+ event + ' has been clicked!';
  }
}
