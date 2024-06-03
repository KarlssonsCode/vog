import { Injectable } from '@angular/core';
import {
  CreateUserReviewRequest,
  GetUserReviewResponse,
  UserReviewClient,
} from '../vog-api';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserReviewService {
  constructor(private userReviewClient: UserReviewClient) {}

  getUserReviewsByUserId(userId: number): Observable<GetUserReviewResponse[]> {
    return this.userReviewClient.getUserReviewsByUserId(userId);
  }

  createUserReview(request: CreateUserReviewRequest): Observable<void> {
    return this.userReviewClient.createUserReview(request);
  }
}
