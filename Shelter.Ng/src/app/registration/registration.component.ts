import { Component } from '@angular/core';
import { RegistrationModel } from '../../models/registration';
import { AuthService } from '../../services/authService';
import { LocalService } from '../../services/localService';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.scss'
})
export class RegistrationComponent {
  constructor(private authService: AuthService,
    private localService: LocalService
  ){}

  errorMessage: string = '';
  registrationModel = new RegistrationModel();

  onRegistration(){
    this.authService.registration(this.registrationModel).subscribe(data =>{
      this.localService.put(LocalService.AuthTokenName ,data);
     
      window.location.href = '/home'
    },
  errorResponse => {
    this.errorMessage = errorResponse.error;
  })
  }
}

