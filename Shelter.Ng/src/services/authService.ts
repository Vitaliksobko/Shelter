import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { LoginModel } from "../models/login";
import { RegistrationModel } from "../models/registration";
import { IdRoleModel } from "../models/idRoleModel";


@Injectable({
  providedIn: "root"
})
export class AuthService {
  constructor(private http: HttpClient) {}

  login(loginModel: LoginModel): Observable<IdRoleModel> {
    return this.http.post<IdRoleModel>("api/auth/login", loginModel);
  }

  registration(registrationModel: RegistrationModel): Observable<string> {
    return this.http.post<string>("api/auth/registration", registrationModel);
  }

}