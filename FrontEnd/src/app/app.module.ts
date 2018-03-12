import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { GameComponent } from './components/game/game.component';
import { GamesService } from './services/games.service';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './components/home/home.component';
import { APP_ROUTING } from './app.routes';
import { OrderByPipe } from './pipes/order-by.pipe';
import { StatisticsComponent } from './components/statistics/statistics.component';
import { PlayersService } from './services/players.service';
import { LogComponent } from './components/log/log.component';
import { LogsService } from './services/logs.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    GameComponent,
    HomeComponent,
    OrderByPipe,
    StatisticsComponent,
    LogComponent
  ],
  imports: [
    BrowserModule,
    APP_ROUTING,
    FormsModule,
    HttpClientModule,
    NgbModule.forRoot()
  ],
  providers: [
    GamesService,
    PlayersService,
    LogsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
