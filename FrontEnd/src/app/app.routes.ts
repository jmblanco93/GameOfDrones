
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { GameComponent } from './components/game/game.component';
import { StatisticsComponent } from './components/statistics/statistics.component';

const ROUTES: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'game/:id', component: GameComponent },
    { path: 'statistics', component: StatisticsComponent },
    { path: '', pathMatch: 'full', redirectTo: 'home' },
    { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

export const APP_ROUTING = RouterModule.forRoot(ROUTES, {useHash: true});
