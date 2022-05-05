import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Customer } from '../Models/Customer';
@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  myAppUrl = 'https://localhost:44391/';
  myApiUrl1 = 'api/Customer';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient) { }

  getCustomer(){
    return this.http.get<Customer[]>(this.myAppUrl + this.myApiUrl1);
  }
}
