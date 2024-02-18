import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LocalService } from '../../services/localService';
import { UserService } from '../../services/userService';
import { UserModel } from '../../models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  

  email: string = "";
  password: string = "";

  errorMessage: string  = '';

  isAdmin: boolean = false;

  constructor(private  localService: LocalService,
    private loginService: UserService, private router : Router,
    private jwtHelperService: JwtHelperService){

  }

  onLogin(){
    let user = new UserModel();

    user.email = this.email;
    user.password = this.password;
    
    this.loginService.login(user).subscribe(data =>{
      this.localService.put(LocalService.AuthTokenName, data);
      
      let token = this.localService.get(LocalService.AuthTokenName);
     
      if(token){
        let decodedData = this.jwtHelperService.decodeToken(token);
        this.isAdmin = decodedData.role == "Admin";
        window.location.href = '/';
      }
    },
    errorResponse =>{
      this.errorMessage = errorResponse.error;
    })
  }

}