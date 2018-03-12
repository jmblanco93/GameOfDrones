import { Component, OnInit } from '@angular/core';
import { LogsService } from '../../services/logs.service';

@Component({
  selector: 'app-log',
  templateUrl: './log.component.html',
  styles: []
})
export class LogComponent implements OnInit {

  logs: any = {};
  loadingLogs = false;
  currentPage = 1;
  errorLogs: any;

  constructor(private _logsService: LogsService) { }

  ngOnInit() {
    this.loadingLogs = true;
    this._logsService.getLogs().subscribe(res => {
      this.logs = res;
      this.loadingLogs = false;
    }, errorValue => {
      this.loadingLogs = false;
      this.errorLogs = errorValue.error;
    });
  }

}
