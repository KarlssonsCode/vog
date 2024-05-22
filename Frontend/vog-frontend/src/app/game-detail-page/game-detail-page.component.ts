import { Component, OnInit } from '@angular/core';
import { RawgGame } from '../../rawg-service';
import { RawgService } from '../../services/rawg.service';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MetacriticScoreComponent } from '../components/metacritic-score/metacritic-score.component';
import { BacklogService } from '../../services/backlog.service';
import { CreateBacklogRequest } from '../../vog-api';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-game-detail-page',
  standalone: true,
  imports: [CommonModule, MetacriticScoreComponent],
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
    private backlogService: BacklogService
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
    this.backlogService.addToBacklog(backlogRequest);
  }
}
