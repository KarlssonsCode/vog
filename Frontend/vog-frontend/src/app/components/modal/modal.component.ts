import { Component, Input } from '@angular/core';
import { RawgGame } from '../../../rawg-service';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.scss',
})
export class ModalComponent {
  @Input() game: RawgGame;

  constructor() {
    this.game = {} as RawgGame;
  }
}
