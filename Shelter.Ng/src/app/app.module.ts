import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, provideHttpClient, withFetch } from '@angular/common/http';

import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';




import { RouterModule } from '@angular/router';
import { AnimalComponent } from './animal/animal.component';
import { AnimalDetailsComponent } from './animal-details/animal-details.component';
import { AdminComponent } from './admin/admin.component';
import { AdminRoutingModule } from './admin/admin-routing.module';
import { AdminAnimalComponent } from './admin/admin-animal/admin-animal.component';
import { AnimalCreateComponent } from './admin/admin-animal/animal-create/animal-create.component';
import { HomeComponent } from './home/home.component';
import { NewsComponent } from './news/news.component';
import { AdminNewsComponent } from './admin/admin-news/admin-news.component';
import { CreateNewsComponent } from './admin/admin-news/create-news/create-news.component';
import { AdminUsersComponent } from './admin/admin-users/admin-users.component';
import { AminalUpdateComponent } from './admin/admin-animal/aminal-update/aminal-update.component';
import { NewsUpdateComponent } from './admin/admin-news/news-update/news-update.component';
import { TopMenuComponent } from './top-menu/top-menu.component';





@NgModule({
  declarations: [
    AppComponent,
  
    LoginComponent,
    RegistrationComponent,
    AnimalComponent,
    AnimalDetailsComponent,
    AdminComponent,
    AdminAnimalComponent,
    AnimalCreateComponent,
    HomeComponent,
    NewsComponent,
    AdminNewsComponent,
    CreateNewsComponent,
    AdminUsersComponent,
    AminalUpdateComponent,
    NewsUpdateComponent,
    TopMenuComponent

    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    AdminRoutingModule
    
   
  ],
  providers: [
    provideHttpClient(withFetch())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
