import { Component, OnInit } from '@angular/core';
import { BacklogService } from '../../services/backlog.service';
import { GetBacklogResponse } from '../../vog-api';
import { UserService } from '../../services/user.service';
import { CommonModule } from '@angular/common';
import { MetacriticScoreComponent } from '../components/metacritic-score/metacritic-score.component';
import { FormsModule } from '@angular/forms';
import { ReviewModalComponent } from '../components/review-modal/review-modal.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

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
  backlogAmount: number | null = null;
  backlogItems: GetBacklogResponse[] = [];

  constructor(
    private backlogService: BacklogService,
    private userService: UserService,
    private modalService: NgbModal
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

  removeFromBacklog(backlogId: number): void {
    this.backlogService.removeGameFrombacklog(backlogId).subscribe(
      () => {
        this.backlogItems = this.backlogItems.filter(
          item => item.id !== backlogId
        );
        this.countBacklogGames();
      },
      error => {
        console.error('Error removing backlog item:', error);
      }
    );
  }

  orderBacklogByMetacriticScore(): void {
    this.backlogItems.sort((a, b) => b.metacritic - a.metacritic);
  }

  countBacklogGames(): void {
    this.backlogAmount = this.backlogItems.length;
  }

  openReviewModal(item: GetBacklogResponse) {
    const modalRef = this.modalService.open(ReviewModalComponent);
    modalRef.componentInstance.userId = this.userId;
    modalRef.componentInstance.rawgId = item.rawgId;
    modalRef.componentInstance.rawgTitle = item.title;
    modalRef.componentInstance.backgroundImage = item.backgroundImage;
    modalRef.componentInstance.releaseDate = item.releaseDate;
    modalRef.componentInstance.description = item.description;
    modalRef.componentInstance.metacritic = item.metacritic;
  }
}
