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





const routes: Routes = [
  {path: "admin", component: AdminComponent},
  {path: "admin-animal", component: AdminAnimalComponent},
  {path: "admin-animal/create-animal", component: AnimalCreateComponent},
  {path: "admin-animal/edit-animal/:id", component: AminalUpdateComponent},
  {path: "admin-animal/edit-news/:id", component: NewsUpdateComponent},
  {path: "admin-news", component: AdminNewsComponent},
  {path: "admin-news/create-news", component: CreateNewsComponent},
  {path: "admin-user", component: AdminUsersComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }