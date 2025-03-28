import { Component } from '@angular/core';
import { LoginDetailsService } from '../../shared/login-details.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login-details-form',
  templateUrl: './login-details-form.component.html',
  styleUrl: './login-details-form.component.css'
})
export class LoginDetailsFormComponent {
  constructor(public service: LoginDetailsService) { }
  onSubmit(form: NgForm) {
    if (form.invalid) return;

    const Login = form.value.loginName.toString().trim();
    const Password = form.value.password.toString().trim();

    this.service.checkCredentials(Login, Password).subscribe({
      next: (isValid) => {
        if (isValid) {
          console.log("Zalogowano pomyślnie – przekierowanie...");
        }
        else {
          console.log("Błędny login lub hasło.");
        }
      },
      error: (err) => console.error("Błąd zapytania:", err)
    });
  }
}
