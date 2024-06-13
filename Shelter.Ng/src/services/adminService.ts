import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Animal } from "../models/animal";
import { User } from "../models/user";
import { ChangeRoleModel } from "../models/changeRoleModel";
import { AllUserModel } from "../models/allUserModel";
import { AnimalStatus } from "../enum/animalStatus";


@Injectable({providedIn: "root"})
export class AdminService{
    constructor(private client: HttpClient){}
    private apiUrl = '/api/admin'; 
   
    createAnimal(createAnimal: FormData): Observable<any> {
        return this.client.post('api/admin', createAnimal);
    }

    getAnimals(): Observable<Animal[]> {
        return this.client.get<Animal[]>('api/admin/animals');
    }

    getUsers(): Observable<AllUserModel[]> {
        return this.client.get<AllUserModel[]>('api/admin/users');
    }

    changeRole(changeRole: ChangeRoleModel ): Observable<any>{
        return this.client.put('api/admin/role', changeRole);
    }

    deleteUser(id: string): Observable<any>{
        return this.client.delete('api/admin/user/' + id);
    }

    deleteAnimal(id: string): Observable<any>{
        return this.client.delete('api/admin/animal/' + id);
    }

    updateAnimalStatus(id: string, status: AnimalStatus): Observable<void> {
        return this.client.put<void>(`${this.apiUrl}/animal/${id}/status`, { status });
    }

    adoptConfirm(animalId: string): Observable<any> {
        const url = `${this.apiUrl}/${animalId}/confirm`;
        return this.client.put(url, null); 
    }

    adoptReject(animalId: string): Observable<any> {
        const url = `${this.apiUrl}/${animalId}/reject`;
        return this.client.put(url, null); 
      }

    
}