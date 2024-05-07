import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { RawgGame } from '../rawg-service';

@Injectable({ providedIn: 'root' })
export class RawgService {
  getGames() {
    throw new Error('Method not implemented.');
  }
  API_URL = 'https://api.rawg.io/api/';
  API_KEY = '2d3aad5dadc942bfa3ec90918afaaa10';

  constructor(private http: HttpClient) {}

  getStartingPageGames(): Observable<RawgGame[]> {
    // const gamesUrl = `${this.API_URL}games?dates=2023-01-01%2C2024-12-31&key=${this.API_KEY}&ordering=-metacritic`;
    // const gamesUrl = `${this.API_URL}games?dates=2023-01-01%2C2024-12-31&key=${this.API_KEY}&metacritic=80,100`;
    const gamesUrl = `${this.API_URL}games?dates=2023-01-01%2C2024-12-31&key=${this.API_KEY}&ordering=-added`;

    return this.http
      .get<{ results: RawgGame[] }>(gamesUrl)
      .pipe(map(response => response.results));
  }

  getGameDetails(slug: string): Observable<RawgGame> {
    const url = `${this.API_URL}games/${slug}?key=${this.API_KEY}`;
    return this.http.get<RawgGame>(url);
  }

  searchGames(query: string): Observable<RawgGame[]> {
    return this.http.get<RawgGame[]>(
      `${this.API_URL}games?key=${this.API_KEY}&search=${query}&search_precise=true&ordering=-added`
    );
  }
}
