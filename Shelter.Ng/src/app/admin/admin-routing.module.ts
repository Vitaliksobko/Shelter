import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminAnimalComponent } from './admin-animal/admin-animal.component';
import { AnimalCreateComponent } from './admin-animal/animal-create/animal-create.component';
import { AdminNewsComponent } from './admin-news/admin-news.component';
import { CreateNewsComponent } from './admin-news/create-news/create-news.component';
import { AdminUsersComponent } from './admin-users/admin-users.component';
import { AminalUpdateComponent } from './admin-animal/aminal-update/aminal-update.component';
import { NewsUpdateComponent } from './admin-news/news-update/news-update.component';
import { adminGuard } from './guards/admin.guard';





const routes: Routes = [
  {path: "admin", component: AdminComponent, canActivate: [adminGuard]},
  {path: "admin-animal", component: AdminAnimalComponent, canActivate: [adminGuard]},
  {path: "admin-animal/create-animal", component: AnimalCreateComponent, canActivate: [adminGuard]},
  {path: "admin-animal/edit-animal/:id", component: AminalUpdateComponent, canActivate: [adminGuard]},
  {path: "admin-animal/edit-news/:id", component: NewsUpdateComponent, canActivate: [adminGuard]},
  {path: "admin-news", component: AdminNewsComponent, canActivate: [adminGuard]},
  {path: "admin-news/create-news", component: CreateNewsComponent, canActivate: [adminGuard]},
  {path: "admin-user", component: AdminUsersComponent, canActivate: [adminGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }