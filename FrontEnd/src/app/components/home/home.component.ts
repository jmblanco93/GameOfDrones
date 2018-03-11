import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GamesService } from '../../services/games.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {

  game: any = {};
  errorMessage: any;

  constructor(
    private _gameService: GamesService,
    private _router: Router
  ) { }

  ngOnInit() {
  }

  startGame(form: NgForm) {
    this._gameService.startGame(form.value)
      .subscribe( (res: any) => {
        this._router.navigate(['/game', res.id]);
      }, error => {
        this.errorMessage = error.error;
      });
  }

}
