import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GamesService } from '../../services/games.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styles: []
})
export class GameComponent implements OnInit {

  game: any;
  move: number;
  roundNumber: number;
  currentPlayer: any = {};
  lastStep: boolean;
  round: any = {};
  loadingGame = false;
  errors: any = null;

  constructor(
    private _gameService: GamesService,
    private _activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this._activatedRoute.params.subscribe(params => {
      this.game = null;
      this.loadingGame = true;
      this._gameService.getGame(params.id).subscribe(res => {
        this.loadingGame = false;
        this.game = res;
        this.roundNumber = this.game.rounds.length + 1;
        this.currentPlayer = this.game.player1;
      }, errorRes => {
        this.loadingGame = false;
        console.error(errorRes);
      });
    });
  }

  nextPlayer() {
    this.round.Player1Move = this.move;
    this.currentPlayer = this.game.player2;
    this.lastStep = true;
    this.move = null;
  }

  finishRound() {
    this.round.Player2Move = this.move;
    this.round.sequence = this.roundNumber;
    // llamar servicio de logica de juego
    this._gameService.validateRound(this.game.id, this.round)
      .subscribe(res => {
        this.game = res;
        this.roundNumber += 1;
        this.round = {};
        this.currentPlayer = this.game.player1;
        this.move = null;
        this.lastStep = false;
      });
  }

}
