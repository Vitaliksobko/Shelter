import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../services/adminService';
import { ChangeRoleModel } from '../../../models/changeRoleModel';
import { LocalService } from '../../../services/localService';

import { AllUserModel } from '../../../models/allUserModel';


@Component({
  selector: 'app-admin-users',
  templateUrl: './admin-users.component.html',
  styleUrl: './admin-users.component.scss'
})
export class AdminUsersComponent implements OnInit {
  constructor(
    private adminService: AdminService,
  
    private localService: LocalService
  ) { }

  users: AllUserModel[] = [];
  isAdmin: boolean = false;
  errorMessage: string = '';
  currentUserId: string = '';

  changeRole(id: string) {
    let changeRole = new ChangeRoleModel();
    changeRole.id = id;
    this.adminService.changeRole(changeRole).subscribe(() => {
      this.adminService.getUsers().subscribe(data => {
        this.users = data;
      })
    });
  }

  delete(id: string) {
    this.adminService.deleteUser(id).subscribe(() => {
      this.adminService.getUsers().subscribe(data => {
        this.users = data;
      })
    })
  }

  ngOnInit(): void {
    let token = this.localService.get(LocalService.AuthTokenName);
    if (token) {
      this.currentUserId = token;
    }
    this.adminService.getUsers().subscribe(data => {
      this.users = data;
    },
      errorResponse => {
        this.errorMessage = errorResponse.error;
      })
  }
}