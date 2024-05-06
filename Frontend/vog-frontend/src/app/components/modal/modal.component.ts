import { Component, Input } from '@angular/core';
import { RawgGame } from '../../../rawg-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.scss',
})
export class ModalComponent {
  @Input() game: RawgGame;
  gameDescription: string | null = null;

  constructor() {
    this.game = {} as RawgGame;
  }
}
