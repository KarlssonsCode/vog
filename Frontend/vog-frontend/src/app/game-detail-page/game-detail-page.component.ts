import { Component, OnInit } from '@angular/core';
import { RawgGame } from '../../rawg-service';
import { RawgService } from '../../services/rawg.service';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MetacriticScoreComponent } from '../components/metacritic-score/metacritic-score.component';
import { BacklogService } from '../../services/backlog.service';
import { CreateBacklogRequest } from '../../vog-api';
import { UserService } from '../../services/user.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ReviewModalComponent } from '../components/review-modal/review-modal.component';

@Component({
  selector: 'app-game-detail-page',
  standalone: true,
  imports: [CommonModule, MetacriticScoreComponent, ReviewModalComponent],
  templateUrl: './game-detail-page.component.html',
  styleUrl: './game-detail-page.component.scss',
})
export class GameDetailPageComponent implements OnInit {
  game: RawgGame | null = null;
  userId: number | null = null;

  constructor(
    private route: ActivatedRoute,
    private rawgService: RawgService,
    private userService: UserService,
    private backlogService: BacklogService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.userId = this.userService.userId;
    this.route.params.subscribe(params => {
      const slug = params['slug'];
      this.fetchGameDetails(slug);
    });
  }

  fetchGameDetails(slug: string) {
    this.rawgService.getGameDetails(slug).subscribe((game: RawgGame) => {
      this.game = game;
      console.log(game);
    });
  }
  addToBacklog(
    userId: number,
    rawgId: number,
    rawgTitle: string,
    backgroundImage: string,
    releaseDate: string,
    description: string,
    metacritic?: number
  ) {
    const backlogRequest: CreateBacklogRequest = {
      userId: userId,
      rawgId: rawgId,
      rawgTitle: rawgTitle,
      backgroundImage: backgroundImage,
      releaseDate: releaseDate,
      description: description,
      metacritic: metacritic,
    };
    console.log(backlogRequest);
    this.backlogService.addGameToBacklog(backlogRequest).subscribe(response => {
      console.log('Game added to backlog', response);
    });
  }

  openReviewModal() {
    const modalRef = this.modalService.open(ReviewModalComponent);
    modalRef.componentInstance.userId = this.userId;
    modalRef.componentInstance.rawgId = this.game!.id;
    modalRef.componentInstance.rawgTitle = this.game!.name;
    modalRef.componentInstance.backgroundImage = this.game!.background_image;
    modalRef.componentInstance.releaseDate = this.game!.released;
    modalRef.componentInstance.description = this.game!.description_raw;
    modalRef.componentInstance.metacritic = this.game!.metacritic;
  }
}
