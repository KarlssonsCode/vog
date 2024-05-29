import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomUserListGameService } from '../../services/customUserListGame.service';
import { GetCustomUserListGameResponse } from '../../vog-api';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { MetacriticScoreComponent } from '../components/metacritic-score/metacritic-score.component';

@Component({
  selector: 'app-list-detail-view',
  standalone: true,
  templateUrl: './list-detail-view.component.html',
  styleUrl: './list-detail-view.component.scss',
  imports: [CommonModule, MetacriticScoreComponent],
})
export class ListDetailViewComponent implements OnInit {
  listId: number | null = null;
  games$!: Observable<GetCustomUserListGameResponse[]>;

  constructor(
    private route: ActivatedRoute,
    private customUserListGameService: CustomUserListGameService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.listId = +params['id']; // Convert the string parameter to a number
      this.loadGames();
    });
  }

  loadGames(): void {
    this.games$ = this.customUserListGameService.getCustomListGamesByListId(
      this.listId!
    );
  }
}
