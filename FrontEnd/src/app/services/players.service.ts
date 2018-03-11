import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class PlayersService {

  constructor(public http: HttpClient) { }

  getLeaderboard() {
    return this.http.get(environment.origin + 'players/leaderboard');
  }

}
