import { Component, OnInit } from '@angular/core';
import { UserReviewService } from '../../services/userrReview.service';
import { UserService } from '../../services/user.service';
import { GetUserReviewResponse } from '../../vog-api';
import { MetacriticScoreComponent } from '../components/metacritic-score/metacritic-score.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-reviewed-games-view',
  standalone: true,
  templateUrl: './reviewed-games-view.component.html',
  styleUrl: './reviewed-games-view.component.scss',
  imports: [MetacriticScoreComponent, CommonModule],
})
export class ReviewedGamesViewComponent implements OnInit {
  userId: number | null = null;
  userName: string = '';
  loggedInUserReviews: GetUserReviewResponse[] = [];

  constructor(
    private userReviewService: UserReviewService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.userId = this.userService.userId;
    this.userName = this.userService.userName;
    this.loadLoggedInUserReviews();
  }

  loadLoggedInUserReviews(): void {
    this.userReviewService.getUserReviewsByUserId(this.userId!).subscribe(
      data => {
        this.loggedInUserReviews = data;
      },
      error => {
        console.error('Error fetching backlog:', error);
      }
    );
  }
}
