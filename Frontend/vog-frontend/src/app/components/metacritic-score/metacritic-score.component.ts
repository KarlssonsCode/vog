import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';

type GradingType = 'bad' | 'good' | 'great' | 'excellent' | 'unrated' | '';

@Component({
  selector: 'app-metacritic-score',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './metacritic-score.component.html',
  styleUrl: './metacritic-score.component.scss',
})
export class MetacriticScoreComponent implements OnInit {
  @Input() metacritic: number = 0;
  gradingType: GradingType = '';

  ngOnInit() {
    this.gradingType = this.mapValToClass(this.metacritic);
  }

  private mapValToClass(val: number): GradingType {
    if (val >= 1 && val <= 49) {
      return 'bad';
    } else if (val >= 50 && val <= 69) {
      return 'good';
    } else if (val >= 70 && val <= 94) {
      return 'great';
    } else if (val >= 95 && val <= 100) {
      return 'excellent';
    } else {
      return 'unrated';
    }
  }
}
