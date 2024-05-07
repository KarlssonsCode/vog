/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { RawgService } from '../services/rawg.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'vault-of-games';
  searchQuery: string = '';
  searchResults: any[] = [];
  loading: boolean = false;
  showDropdown: boolean = false;

  constructor(
    private rawgService: RawgService,
    private router: Router
  ) {}

  search() {
    this.loading = true;
    this.rawgService.searchGames(this.searchQuery).subscribe((data: any) => {
      this.searchResults = data.results;
      this.loading = false;
    });
  }

  onInputChange(event: any) {
    const query = event.target.value;
    if (query.length > 2) {
      this.loading = true;
      this.rawgService.searchGames(query).subscribe((data: any) => {
        this.searchResults = data.results;
        this.loading = false;
        this.showDropdown = true; // Show the dropdown when there are search results
      });
    } else {
      this.searchResults = [];
      this.showDropdown = false; // Hide the dropdown when the input length is less than 3 characters
    }
  }

  navigateToGameDetails(slug: string) {
    this.router.navigate(['/game-details', slug]);
  }

  selectGame(game: any) {
    console.log('Selected game:', game);
    // Do something with the selected game, such as navigating to its details page
  }
}
