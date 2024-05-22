import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { API_BASE_URL, BacklogClient, UserClient } from '../vog-api';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { environment } from '../environments/enviroment.development';

export const appConfig: ApplicationConfig = {
  providers: [
    UserClient,
    BacklogClient,
    { provide: API_BASE_URL, useValue: environment.API_URL },
    provideRouter(routes),
    provideHttpClient(),
  ],
};
