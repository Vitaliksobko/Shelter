import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Animal } from "../models/animal";


@Injectable({providedIn: "root"})
export class AdminService{
    constructor(private client: HttpClient){}

   
    createAnimal(createAnimal: FormData): Observable<any> {
        return this.client.post('api/admin', createAnimal);
    }

    getAnimals(): Observable<Animal[]> {
        return this.client.get<Animal[]>('api/admin/animals');
    }
    
}