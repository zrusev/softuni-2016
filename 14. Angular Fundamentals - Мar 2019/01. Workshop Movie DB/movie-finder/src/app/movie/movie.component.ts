import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import Movie from 'src/Models/Movie';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  @Input()
  movie: Movie;

  @Output()
  clickButtonEmitter: EventEmitter<number> = new EventEmitter<number>();

  imagePath: string;


  constructor() { }

  ngOnInit() {
    this.imagePath = 'https://image.tmdb.org/t/p/w500' + this.movie.poster_path;
  }

  clickButton() {
    this.clickButtonEmitter.emit(this.movie.id);
  }

}
