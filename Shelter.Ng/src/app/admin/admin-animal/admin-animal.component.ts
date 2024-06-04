import { Component, OnInit } from '@angular/core';
import { Animal } from '../../../models/animal';
import { AdminService } from '../../../services/adminService';
import { LocalService } from '../../../services/localService';

@Component({
  selector: 'app-admin-animal',
  templateUrl: './admin-animal.component.html',
  styleUrl: './admin-animal.component.scss'
})
export class AdminAnimalComponent  implements OnInit{
  animals: Animal[] = [];
  errorMessage: string = '';
  constructor(private adminService : AdminService, private localService: LocalService) { }

  ngOnInit(): void {
    this.getAnimals();
  }

  getAnimals(): void {
    this.adminService.getAnimals()
      .subscribe(animals => this.animals = animals);
  }

 

}