import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class LogsService {

  constructor(public http: HttpClient) { }

  getLogs() {
    return this.http.get(environment.origin + 'logs');
  }

}
