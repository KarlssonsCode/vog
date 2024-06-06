import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CreateUserReviewRequest } from '../../../vog-api';
import { UserReviewService } from '../../../services/userrReview.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-review-modal',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './review-modal.component.html',
  styleUrl: './review-modal.component.scss',
})
export class ReviewModalComponent {
  @Input() userId!: number;
  @Input() rawgId!: number;
  @Input() rawgTitle!: string;
  @Input() backgroundImage!: string;
  @Input() releaseDate!: string;
  @Input() description!: string;
  @Input() metacritic!: number;
  reviewText: string = '';
  score: number = 0;

  constructor(
    public activeModal: NgbActiveModal,
    private userReviewService: UserReviewService
  ) {}

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  updateScore(event: any) {
    this.score = event.target.value;
  }

  submitReview() {
    const request: CreateUserReviewRequest = {
      userId: this.userId,
      rawgId: this.rawgId,
      rawgTitle: this.rawgTitle,
      backgroundImage: this.backgroundImage,
      releaseDate: this.releaseDate,
      description: this.description,
      metacritic: this.metacritic,
      reviewText: this.reviewText,
      score: this.score,
    };

    this.userReviewService.createUserReview(request).subscribe({
      next: () => {
        this.activeModal.close('Review submitted');
        window.location.reload();
      },
      error: err => {
        console.error('Error creating review', err);
      },
    });
  }
}
