import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { inherits } from 'util';
import { LocalService } from '../../../services/localService';

export const adminGuard: CanActivateFn = (route, state) => {
  const localService = inject(LocalService);

  if (localService.isAdmin(LocalService.AuthRole)){
    return true;
  }
  else{
    window.location.href = '/login'; //fix
    return false;
  }
};
