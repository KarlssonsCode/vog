import { Component, OnInit } from '@angular/core';
import { RawgService } from '../../services/rawg.service';
import { RawgGame } from '../../rawg-service';
import { CommonModule } from '@angular/common';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../components/modal/modal.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-start-view',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './start-view.component.html',
  styleUrl: './start-view.component.scss',
})
export class StartViewComponent implements OnInit {
  startPageGames: RawgGame[] = [];

  constructor(
    private rawgService: RawgService,
    private modal: NgbModal,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.fetchStartPageGames();
  }

  fetchStartPageGames() {
    this.rawgService.getStartingPageGames().subscribe((games: RawgGame[]) => {
      this.startPageGames = games;
      console.log('fetched games', this.startPageGames);
    });
  }

  showGameModal(game: RawgGame) {
    const modalRef = this.modal.open(ModalComponent);
    modalRef.componentInstance.game = game;
  }

  handleImageClick(game: RawgGame) {
    return game;
  }

  navigateToGameDetails(slug: string) {
    this.router.navigate(['/game-details', slug]);
  }
}
