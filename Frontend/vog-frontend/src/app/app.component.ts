/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { RawgService } from '../services/rawg.service';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserService } from '../services/user.service';
import { GetUserResponse } from '../vog-api';
import { RawgGame } from '../rawg-service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CreateAccountModalComponent } from './components/create-account-modal/create-account-modal.component';
import { debounceTime, Subject, switchMap } from 'rxjs';

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
  searchResults: RawgGame[] = [];
  loginError: string | null = null;
  loading: boolean = false;
  showDropdown: boolean = false;
  userName: string = '';
  userId: number | null = null;
  isLoggedIn: boolean = false;
  private searchSubject: Subject<string> = new Subject();

  constructor(
    private rawgService: RawgService,
    private router: Router,
    private userService: UserService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.isLoggedIn = this.userService.isLoggedIn();
    this.userName = this.userService.userName;
    this.userId = this.userService.userId;

    // Subscribe to the search subject with debounce
    this.searchSubject
      .pipe(
        debounceTime(300),
        switchMap(query => {
          this.loading = true;
          return this.rawgService.searchGames(query);
        })
      )
      .subscribe(
        (data: any) => {
          this.searchResults = data.results;
          this.showDropdown = this.searchResults.length > 0;
          this.loading = false;
        },
        error => {
          console.error('Search failed:', error);
          this.loading = false;
        }
      );
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
      },
      error => {
        console.error('AppComponent: Login failed:', error);
      }
    );
  }

  logout() {
    this.userService.logout();
    window.location.reload();
  }

  onSubmit(form: NgForm): void {
    if (form.valid) {
      const { email, password } = form.value;
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

  onInputChange(event: Event): void {
    const query = (event.target as HTMLInputElement).value;
    this.searchQuery = query;
    if (query.length > 2) {
      this.searchSubject.next(query);
    } else {
      this.searchResults = [];
      this.showDropdown = false;
      this.loading = false;
    }
  }

  navigateToGameDetails(slug: string): void {
    this.router.navigate(['/game-details', slug]);
  }

  openCreateAccountModal() {
    const modalRef = this.modalService.open(CreateAccountModalComponent);
    modalRef.result.then(
      result => {
        console.log(result);
      },
      reason => {
        console.log('Dismissed:', reason);
      }
    );
  }
}
