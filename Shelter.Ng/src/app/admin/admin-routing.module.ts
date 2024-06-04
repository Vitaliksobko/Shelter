import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminAnimalComponent } from './admin-animal/admin-animal.component';
import { AnimalCreateComponent } from './admin-animal/animal-create/animal-create.component';




const routes: Routes = [
  {path: "admin", component: AdminComponent},
  {path: "admin-animal", component: AdminAnimalComponent},
  {path: "admin-animal/create-animal", component: AnimalCreateComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }