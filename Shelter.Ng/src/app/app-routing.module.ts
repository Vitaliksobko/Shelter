import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { AnimalComponent } from './animal/animal.component';
import { AnimalDetailsComponent } from './animal-details/animal-details.component';
import { HomeComponent } from './home/home.component';
import { NewsComponent } from './news/news.component';
import { AboutComponent } from './about/about.component';
import { authGuard } from '../guards/auth.guard';
import { NewDetailComponent } from './news/new-detail/new-detail.component';

const routes: Routes = [ 
{ path: "registration", component: RegistrationComponent},
{ path: "login", component: LoginComponent },
{ path: "animal", component: AnimalComponent,canActivate: [authGuard] },
{ path: "currentanimal/:id", component: AnimalDetailsComponent, canActivate: [authGuard] },
{ path: "home", component: HomeComponent },
{ path: "news", component: NewsComponent ,canActivate: [authGuard]},
{ path:"new-detail/:id", component: NewDetailComponent, canActivate: [authGuard]},
{ path: "about", component: AboutComponent , canActivate: [authGuard]},
{ path: '', redirectTo: '/login', pathMatch: 'full' },


];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
