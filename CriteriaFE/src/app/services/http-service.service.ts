import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpServiceService {

  public baseUrl = 'https://localhost:7006' // Local

  constructor(public http: HttpClient) { }

  // POST request
  Post(API: any, payload: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/${API}`, payload);
  }

}
