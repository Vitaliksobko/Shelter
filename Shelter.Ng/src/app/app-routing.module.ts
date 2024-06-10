import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { AnimalComponent } from './animal/animal.component';
import { AnimalDetailsComponent } from './animal-details/animal-details.component';
import { HomeComponent } from './home/home.component';
import { NewsComponent } from './news/news.component';
import { AboutComponent } from './about/about.component';

const routes: Routes = [ 
{ path: "registration", component: RegistrationComponent},
{ path: "login", component: LoginComponent },
{ path: "animal", component: AnimalComponent },
{ path: "currentanimal/:id", component: AnimalDetailsComponent },
{ path: "home", component: HomeComponent },
{ path: "news", component: NewsComponent },
{ path: "about", component: AboutComponent }

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
