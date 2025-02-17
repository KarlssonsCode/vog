import { Component } from '@angular/core';
import { BacklogService } from '../../services/backlog.service';
import { GetBacklogResponse } from '../../vog-api';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-profile-view',
  standalone: true,
  imports: [],
  templateUrl: './profile-view.component.html',
  styleUrl: './profile-view.component.scss',
})
export class ProfileViewComponent {
  userId: number | null = null;
  userName: string = '';
  backlogAmount: number | null = null;
  backlogItems: GetBacklogResponse[] = [];

  constructor(
    private backlogService: BacklogService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.userId = this.userService.userId;
    this.userName = this.userService.userName;
    this.loadBacklog();
  }

  loadBacklog(): void {
    this.backlogService.getUserBacklog(this.userId!).subscribe(
      data => {
        this.backlogItems = data;
        this.countBacklogGames();
      },
      error => {
        console.error('Error fetching backlog:', error);
      }
    );
  }

  countBacklogGames(): void {
    this.backlogAmount = this.backlogItems.length;
  }
}
