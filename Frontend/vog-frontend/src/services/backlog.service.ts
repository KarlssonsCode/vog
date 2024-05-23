import { Injectable } from '@angular/core';
import { BacklogClient, CreateBacklogRequest } from '../vog-api';
import { Observable, catchError, of, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BacklogService {
  constructor(private backlogClient: BacklogClient) {}

  addGameToBacklog(requestBody: CreateBacklogRequest): Observable<void> {
    return this.backlogClient.addToBackLog(requestBody).pipe(
      tap(response => console.log('API response', response)),
      catchError(error => {
        console.error('Error occurred', error);
        return of(error); // or handle error appropriately
      })
    );
  }
}
