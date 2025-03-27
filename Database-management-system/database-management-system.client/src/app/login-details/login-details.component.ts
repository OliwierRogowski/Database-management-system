import { Component, OnInit } from '@angular/core';
import { LoginDetailsService } from '../shared/login-details.service';

@Component({
  selector: 'app-login-details',
  templateUrl: './login-details.component.html',
  styleUrl: './login-details.component.css'
})
export class LoginDetailsComponent implements OnInit{
  constructor(public service: LoginDetailsService) { }
  ngOnInit(): void {
    console.log('✅ ngOnInit działa!');
      this.service.refreshList();
    }
}
