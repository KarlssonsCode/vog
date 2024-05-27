import { Component, OnInit } from '@angular/core';
import { BacklogService } from '../../services/backlog.service';
import { GetBacklogResponse } from '../../vog-api';
import { UserService } from '../../services/user.service';
import { CommonModule } from '@angular/common';
import { MetacriticScoreComponent } from '../components/metacritic-score/metacritic-score.component';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-backlog-view',
  standalone: true,
  templateUrl: './backlog-view.component.html',
  styleUrl: './backlog-view.component.scss',
  imports: [CommonModule, MetacriticScoreComponent, FormsModule],
})
export class BacklogViewComponent implements OnInit {
  userId: number | null = null;
  userName: string = '';
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
      },
      error => {
        console.error('Error fetching backlog:', error);
      }
    );
  }

  removeFromBacklog(backlogId: number): void {
    this.backlogService.removeGameFrombacklog(backlogId).subscribe(
      () => {
        this.backlogItems = this.backlogItems.filter(
          item => item.id !== backlogId
        );
      },
      error => {
        console.error('Error removing backlog item:', error);
      }
    );
  }
}
