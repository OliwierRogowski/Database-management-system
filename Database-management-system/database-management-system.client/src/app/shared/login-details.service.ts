import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from '../../environments/environment';
import { LoginDetails } from './login-details.model';

@Injectable({
  providedIn: 'root'
})
export class LoginDetailsService {
  url: string = environment.apiBaseUrl + '/LoginDetails'

  list: LoginDetails[] = []
  constructor(private http: HttpClient) {

  }
  refreshList() {
    this.http.get(this.url)
      .subscribe({
        next: res => {
          this.list = res as LoginDetails[];
         console.log(res)
        },
        error: err => {
          console.log('Błąd pobierania danych:', err);
        }
      });
  }
}
