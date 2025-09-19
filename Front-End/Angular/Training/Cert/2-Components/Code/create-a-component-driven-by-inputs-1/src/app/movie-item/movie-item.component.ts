// src/app/movie-item/movie-item.component.ts

import { Component, input } from '@angular/core';
import { Movie } from '../model/movie.model';

@Component({
  selector: 'app-movie-item',
  template: `
    <div class="movie-item">
      <div>
        <h4>{{movie().title}}</h4>
        <small class="subtitle">
          <span>Release date: {{movie().release_date}}</span>
          <span>Budget: {{movie().budget}}</span>
          <span>Duration: {{movie().duration}}</span>
        </small>
      </div>
      <button>Details</button>
    </div>
  `,
  standalone: true,
  styleUrls: [ 'movie-item.component.scss' ]
})
export class MovieItemComponent {
  // @Input({required: true}) movie!: Movie;
  movie = input.required<Movie>();
}

