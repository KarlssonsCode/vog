import { Injectable } from '@angular/core';
import {
  CreateCustomUserListRequest,
  CustomUserListClient,
  GetCustomUserListResponse,
} from '../vog-api';
import { Observable, catchError, of, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CustomUserListService {
  constructor(private customUserListClient: CustomUserListClient) {}

  createCustomUserList(
    requestBody: CreateCustomUserListRequest
  ): Observable<void> {
    return this.customUserListClient.createCustomList(requestBody).pipe(
      tap(response => console.log('API response', response)),
      catchError(error => {
        console.error('Error occurred', error);
        return of(error); // or handle error appropriately
      })
    );
  }

  getCustomUserListsById(
    userId: number
  ): Observable<GetCustomUserListResponse[]> {
    return this.customUserListClient.getCustomUserListsById(userId);
  }
}
