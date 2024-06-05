import { Component, OnInit } from '@angular/core';
import { LocalService } from '../../services/localService';

@Component({
  selector: 'app-top-menu',
  templateUrl: './top-menu.component.html',
  styleUrl: './top-menu.component.scss'
})
export class TopMenuComponent  implements OnInit {
  constructor(private localService: LocalService){}

  isAuthorized: boolean = false;
  isAdmin: boolean = false; // Add this variable for Admin role
  isCartOpen = false;

  onExit() {
    this.isAuthorized = false;
    this.localService.remove(LocalService.AuthTokenName);
    this.localService.remove(LocalService.AuthRole);
    window.location.href = '/login';
  }

  ngOnInit(): void {
    let token = this.localService.get(LocalService.AuthTokenName);

    if(token) {
      this.isAuthorized = true;
      let role = this.localService.get(LocalService.AuthRole);
      if (role === 'Admin') {
        this.isAdmin = true;
      }
    }
  }
}