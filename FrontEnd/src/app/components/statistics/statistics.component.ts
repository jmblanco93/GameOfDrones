import { Component, OnInit } from '@angular/core';
import { GamesService } from '../../services/games.service';
import { PlayersService } from '../../services/players.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styles: []
})
export class StatisticsComponent implements OnInit {

  games: any = [];
  leaders: any = [];
  leadersPage = 1;
  gameHistoryPage = 1;
  loadingLeaders = false;
  loadingGames = false;

  constructor(
    private _gamesService: GamesService,
    private _playerService: PlayersService
  ) { }

  ngOnInit() {
    this.loadingGames = true;
    this._gamesService.getGames().subscribe(res => {
      this.games = res;
      this.loadingGames = false;
    });
    this.loadingLeaders = true;
    this._playerService.getLeaderboard().subscribe( res => {
      this.leaders = res;
      this.loadingLeaders = false;
    });
  }

}
