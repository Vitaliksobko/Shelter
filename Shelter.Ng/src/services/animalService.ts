import { Injectable, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Animal } from "../models/animal";
import { Booking } from "../models/booking";

@Injectable({
  providedIn: 'root'
})
export class AnimalService {

  private apiUrl = '/api/animal'; 

  constructor(private http: HttpClient) { }

  getAnimals(): Observable<Animal[]> {
    return this.http.get<Animal[]>(this.apiUrl);
  }

  getAnimal(id: string): Observable<any> {
    return this.http.get<Animal>('api/animal/' + id);
  }

  bookAnimal(animalId: string, booking: Booking): Observable<Booking> {
    return this.http.post<Booking>(`${this.apiUrl}/${animalId}/book`, booking);
  }

  updateAnimal(updateProductModel: FormData): Observable<any> {
    return this.http.put('api/animal', updateProductModel);
  }

  adoptAnimal(animalId: string): Observable<any> {
    const url = `${this.apiUrl}/${animalId}/adopt`;
    return this.http.put(url, null); 
  }



  

}