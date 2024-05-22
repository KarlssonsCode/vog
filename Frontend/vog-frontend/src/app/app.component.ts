/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { RawgService } from '../services/rawg.service';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserService } from '../services/user.service';
import { GetUserResponse } from '../vog-api';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  title = 'vault-of-games';
  searchQuery: string = '';
  searchResults: any[] = [];
  loginError: string | null = null;
  loading: boolean = false;
  showDropdown: boolean = false;
  userName: string = '';
  userId: number | null = null;

  constructor(
    private rawgService: RawgService,
    private router: Router,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.userName = this.userService.userName;
    this.userId = this.userService.userId;
  }

  login(email: string, password: string): void {
    console.log('AppComponent: Calling login with email:', email);
    this.userService.login(email, password).subscribe(
      (response: GetUserResponse) => {
        this.userService.setUser(response.id, response.username);
        console.log(
          'AppComponent: Login successful, username:',
          response.username
        );
        window.location.reload();
        // Handle successful login
      },
      error => {
        console.error('AppComponent: Login failed:', error);
        // Handle login error
      }
    );
  }

  onSubmit(form: NgForm): void {
    if (form.valid) {
      const { email, password } = form.value;
      console.log('AppComponent: Form submitted with email:', email);
      this.login(email, password);
    } else {
      console.log('AppComponent: Form is invalid');
    }
  }

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
