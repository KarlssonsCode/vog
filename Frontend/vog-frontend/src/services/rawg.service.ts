import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { RawgGame } from '../rawg-service';

@Injectable({ providedIn: 'root' })
export class RawgService {
  API_URL = 'https://api.rawg.io/api/';
  API_KEY = '';

  constructor(private http: HttpClient) {}

  getStartingPageGames(): Observable<RawgGame[]> {
    const gamesUrl = `${this.API_URL}games?dates=2023-01-01%2C2024-12-31&key=${this.API_KEY}&ordering=-metacritic`;
    // const gamesUrl = `${this.API_URL}games?dates=2023-01-01%2C2024-12-31&key=${this.API_KEY}&metacritic=80,100`;
    // const gamesUrl = `${this.API_URL}games?dates=2023-01-01%2C2024-12-31&key=${this.API_KEY}&ordering=-added`;

    return this.http
      .get<{ results: RawgGame[] }>(gamesUrl)
      .pipe(map(response => response.results));
  }

  getGameDetails(slug: string): Observable<RawgGame> {
    const url = `${this.API_URL}games/${slug}?key=${this.API_KEY}`;
    return this.http.get<RawgGame>(url);
  }
}
