import { Injectable } from '@angular/core';
import { GetUserReviewResponse, UserReviewClient } from '../vog-api';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserReviewService {
  constructor(private userReviewClient: UserReviewClient) {}

  getUserReviewsByUserId(userId: number): Observable<GetUserReviewResponse[]> {
    return this.userReviewClient.getUserReviewsByUserId(userId);
  }
}
