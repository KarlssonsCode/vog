import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { UserService } from '../../../services/user.service';
import { CreateUserRequest } from '../../../vog-api';

@Component({
  selector: 'app-create-account-modal',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './create-account-modal.component.html',
  styleUrl: './create-account-modal.component.scss',
})
export class CreateAccountModalComponent {
  username: string = '';
  email: string = '';
  password: string = '';

  constructor(
    public activeModal: NgbActiveModal,
    private userService: UserService
  ) {}

  createUser() {
    const request: CreateUserRequest = {
      username: this.username,
      email: this.email,
      password: this.password,
    };

    this.userService.createUser(request).subscribe({
      next: () => {
        this.activeModal.close('User Created');
      },
      error: err => {
        console.error('Error creating review', err);
      },
    });
  }
}
