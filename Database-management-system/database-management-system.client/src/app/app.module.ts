import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginDetailsComponent } from './login-details/login-details.component';
import { LoginDetailsFormComponent } from './login-details/login-details-form/login-details-form.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginDetailsComponent,
    LoginDetailsFormComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
