import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import MovieDetails from 'src/models/Movie-Details';
import { MoviesService } from '../movies.service';

@Injectable()
export class SingleMovieResolver implements Resolve<MovieDetails> {
    constructor(private moviesService: MoviesService) {}

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const id = route.params['id'];

        return this.moviesService.getMovieById(id);
    }
}
