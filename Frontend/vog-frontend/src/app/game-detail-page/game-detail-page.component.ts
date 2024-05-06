import { Component, OnInit } from '@angular/core';
import { RawgGame } from '../../rawg-service';
import { RawgService } from '../../services/rawg.service';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-game-detail-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './game-detail-page.component.html',
  styleUrl: './game-detail-page.component.scss',
})
export class GameDetailPageComponent implements OnInit {
  game: RawgGame | null = null;

  constructor(
    private route: ActivatedRoute,
    private rawgService: RawgService
  ) {}

  ngOnInit(): void {
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
}
