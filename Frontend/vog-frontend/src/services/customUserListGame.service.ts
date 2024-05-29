import { Injectable } from '@angular/core';
import {
  CustomUserListGameClient,
  GetCustomUserListGameResponse,
} from '../vog-api';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CustomUserListGameService {
  constructor(private customUserListGameClient: CustomUserListGameClient) {}

  getCustomListGamesByListId(
    listId: number
  ): Observable<GetCustomUserListGameResponse[]> {
    return this.customUserListGameClient.getCustomUserListGamesByListId(listId);
  }
}
