import { Component, OnInit } from '@angular/core';
import { CustomUserListService } from '../../services/customUserList.service';
import {
  CreateCustomUserListRequest,
  GetCustomUserListResponse,
} from '../../vog-api';
import { Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-list-view',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './list-view.component.html',
  styleUrl: './list-view.component.scss',
})
export class ListViewComponent implements OnInit {
  userId: number | null = null;
  customUserLists: GetCustomUserListResponse[] = [];

  customUserListRequest: CreateCustomUserListRequest = {
    userId: this.userId!,
    name: 'Insert List name',
    description: 'Insert a description',
  };

  constructor(
    private customUserListService: CustomUserListService,
    private userService: UserService
  ) {}
  ngOnInit(): void {
    this.userId = this.userService.userId;
    this.customUserListRequest.userId = this.userId!;
    this.loadLoggedInUserList();
  }

  onSubmit(): void {
    this.customUserListService
      .createCustomUserList(this.customUserListRequest)
      .subscribe({
        next: () => {
          console.log('Custom list created successfully');
          // Handle success
        },
        error: err => {
          console.error('Error creating custom list', err);
          // Handle error
        },
      });
  }

  loadLoggedInUserList(): void {
    this.customUserListService
      .getCustomUserListsById(this.userId!)
      .subscribe(data => {
        this.customUserLists = data;
      });
  }

  createCustomList(requestBody: CreateCustomUserListRequest): Observable<void> {
    return this.customUserListService.createCustomUserList(requestBody);
  }
}
