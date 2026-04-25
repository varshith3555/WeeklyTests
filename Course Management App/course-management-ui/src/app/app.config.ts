import { ApplicationConfig } from '@angular/core';
import { provideHttpClient } from '@angular/common/http';
import { API_BASE_URL } from './api-base-url';

export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(),
    {
      provide: API_BASE_URL,
      useValue: 'http://localhost:5025'
    }
  ]
};
