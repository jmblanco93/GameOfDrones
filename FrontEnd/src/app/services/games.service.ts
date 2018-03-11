import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class GamesService {

  constructor(public http: HttpClient) { }

  startGame(game: any) {
    return this.http.post(environment.origin + 'games', game);
  }

  getGame(id: string) {
    return this.http.get(environment.origin + 'games/' + id);
  }

  validateRound(gameId: string, round: any) {
    return this.http.post(environment.origin + 'games/' + gameId + '/rounds', round);
  }

  getGames() {
    return this.http.get(environment.origin + 'games');
  }

}
