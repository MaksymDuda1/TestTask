import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { JWT_OPTIONS, JwtModule } from '@auth0/angular-jwt';
import { jwtFactory } from './jwt-options';
import { LocalService } from '../services/localService';
import { AuthTokenAddInetrceptor } from '../services/inceptors/auth-token.inceptor';
import { TopMenuComponent } from './top-menu/top-menu.component';
import { InfoComponent } from './home/info/info.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AboutComponent } from './about/about.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    TopMenuComponent,
    InfoComponent,
    AboutComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
   

    JwtModule.forRoot({
      jwtOptionsProvider: {
        provide: JWT_OPTIONS,
        useFactory : jwtFactory,
        deps: [LocalService]
      }
    }),

  ],
  providers: [{
    provide:[HTTP_INTERCEPTORS],
    useClass: AuthTokenAddInetrceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
