import { Component } from '@angular/core';
import { LocalService } from '../../services/localService';
import { Router } from '@angular/router';
import { UserService } from '../../services/userService';
import { UserModel } from '../../models/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  constructor(private localService: LocalService,
    private userService: UserService,  private router : Router){

  }

  firstName: string  = '';  
  lastName: string = '';
  email: string = '';
  password: string = '';

  errorMessage: string = "";

  onRegister(){
    let user = new UserModel();
    
    user.email = this.email;
    user.password = this.password;

    this.userService.register(user).subscribe(data =>{
      this.localService.put(LocalService.AuthTokenName, data);
      window.location.href = '/';
    },
    errorRespone => {
      this.errorMessage = errorRespone.error;
    })
  }
}