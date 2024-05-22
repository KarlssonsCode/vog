import { Injectable } from '@angular/core';
import { BacklogClient, CreateBacklogRequest } from '../vog-api';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BacklogService {
  constructor(private backlogClient: BacklogClient) {}

  addToBacklog(requestBody: CreateBacklogRequest): Observable<void> {
    return this.backlogClient.addToBackLog(requestBody);
  }
}
