import { Component } from '@angular/core';
import { LoginModel } from '../../models/login';
import { AuthService } from '../../services/authService';
import { LocalService } from '../../services/localService';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  constructor(private authService: AuthService,
    private localService: LocalService,
    ){}

  
  loginModel = new LoginModel();
  errorMessage: string = '';


  onLogin(){
    this.authService.login(this.loginModel).subscribe(data => {
      this.localService.put(LocalService.AuthTokenName,data.userId);
      this.localService.put(LocalService.AuthRole,data.role);

     

      let token = this.localService.get(LocalService.AuthTokenName);
      let role = this.localService.get(LocalService.AuthRole);
      if(role == 'Admin')
      window.location.href = '/admin';
      else 
      window.location.href = '/home'
      
    },
    errorResponse => {
      this.errorMessage = errorResponse.error;
    })
  }
}