import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { GetUserResponse, UserClient } from '../vog-api';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private _userId: number | null = null;
  private _userName: string = '';

  constructor(private userClient: UserClient) {
    this.loadUser();
  }

  login(email: string, password: string): Observable<GetUserResponse> {
    console.log(`UserService: login called with email: ${email}`);
    return this.userClient
      .loginByEmailAndPassword(email, password)
      .pipe(tap(response => console.log('API response', response)));
  }

  private loadUser() {
    const userId = localStorage.getItem('userId');
    const userName = localStorage.getItem('userName');

    if (userId) {
      this.userId = +userId; // '+' converts the string to a number
    }
    if (userName) {
      this.userName = userName;
    }
  }

  get userId(): number | null {
    return this._userId;
  }
  set userId(value: number | null) {
    this._userId = value;
    localStorage.setItem('userId', value?.toString() ?? '');
  }

  get userName(): string {
    return this._userName;
  }
  set userName(value: string) {
    this._userName = value;
    localStorage.setItem('userName', value);
  }

  setUser(id: number, name: string) {
    this.userId = id;
    this.userName = name;
  }
}
