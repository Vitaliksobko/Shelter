import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../services/adminService';
import { ChangeRoleModel } from '../../../models/changeRoleModel';
import { LocalService } from '../../../services/localService';
import { AllUserModel } from '../../../models/allUserModel';

@Component({
  selector: 'app-admin-users',
  templateUrl: './admin-users.component.html',
  styleUrls: ['./admin-users.component.scss'] // Виправлено 'styleUrl' на 'styleUrls'
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
      // Знаходимо користувача та оновлюємо його роль локально
      const user = this.users.find(user => user.id === id);
      if (user) {
        user.isAdmin = !user.isAdmin; // Оновлюємо значення isAdmin локально
      }
    });
  }

  delete(id: string) {
    this.adminService.deleteUser(id).subscribe(() => {
      this.users = this.users.filter(user => user.id !== id); // Видаляємо користувача з локального масиву
    });
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
    });
  }
}
