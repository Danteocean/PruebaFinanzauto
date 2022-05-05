import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Account } from '../Models/Account';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {
  myAppUrl = 'https://localhost:44391/';
  myApiUrl = 'api/Accounts';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient) { }

  getAccounts(id: number) {
    return this.http.get<Account[]>(this.myAppUrl + this.myApiUrl+"/" + id);
  }
  saveAccounts(account:Account): Observable<Account> {
    return this.http.post<Account>(this.myAppUrl + this.myApiUrl,account);
  }
}
