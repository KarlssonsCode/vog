import { Routes } from '@angular/router';
import { BacklogViewComponent } from './backlog-view/backlog-view.component';
import { ToplistViewComponent } from './toplist-view/toplist-view.component';
import { StartViewComponent } from './start-view/start-view.component';
import { ProfileViewComponent } from './profile-view/profile-view.component';

export const routes: Routes = [
  {
    path: '',
    component: StartViewComponent,
    title: 'Start',
  },

  {
    path: 'backlog',
    component: BacklogViewComponent,
    title: 'Backlog',
  },

  {
    path: 'toplist',
    component: ToplistViewComponent,
    title: 'Toplist',
  },

  {
    path: 'profile',
    component: ProfileViewComponent,
    title: 'Profile',
  },
];
