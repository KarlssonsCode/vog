import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import {
  API_BASE_URL,
  BacklogClient,
  CustomUserListClient,
  CustomUserListGameClient,
  UserClient,
  UserReviewClient,
} from '../vog-api';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { environment } from '../environments/enviroment.development';

export const appConfig: ApplicationConfig = {
  providers: [
    UserClient,
    BacklogClient,
    CustomUserListClient,
    UserReviewClient,
    CustomUserListGameClient,
    { provide: API_BASE_URL, useValue: environment.API_URL },
    provideRouter(routes),
    provideHttpClient(),
  ],
};
