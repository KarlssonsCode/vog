import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { UserClient } from '../vog-api';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private _userId: number | null = null;
  private _userName: string = '';

  constructor(private userClient: UserClient) {
    this.loadUser();
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

  getUserById(userId: number): Observable<void> {
    return this.userClient
      .userGET2(userId)
      .pipe(tap(response => console.log('API response:', response)));
  }

  setUser(id: number, name: string) {
    this.userId = id;
    this.userName = name;
  }

  // clearUser() {
  //   this.userId = null;
  //   this.userName = '';
  //   this.bookedAndReportedActivities = [];
  //   localStorage.removeItem('userId');
  //   localStorage.removeItem('userName');
  //   localStorage.removeItem('bookedAndReportedActivities');
  // }
}
