import { Component, OnInit, ViewChild } from '@angular/core';
import { Animal } from '../../../models/animal';
import { AdminService } from '../../../services/adminService';
import { LocalService } from '../../../services/localService';
import { AnimalCreateComponent } from './animal-create/animal-create.component';

@Component({
  selector: 'app-admin-animal',
  templateUrl: './admin-animal.component.html',
  styleUrl: './admin-animal.component.scss'
})
export class AdminAnimalComponent  implements OnInit{
  @ViewChild(AnimalCreateComponent) animalCreateComponent!: AnimalCreateComponent;
  animals: Animal[] = [];
  errorMessage: string = '';
  constructor(private adminService : AdminService, private localService: LocalService) { }

  ngOnInit(): void {
    this.getAnimals();
   
  }
  ngAfterViewInit(): void {
    this.animalCreateComponent.animalCreated.subscribe(() => {
      this.getAnimals(); 
    });
  }

  getAnimals(): void {
    this.adminService.getAnimals()
      .subscribe(animals => this.animals = animals);
  }

  delete(id: string) {
    this.adminService.deleteAnimal(id).subscribe(
      () => {
        console.log('product deleted successfully');
        this.adminService.getAnimals().subscribe(data => {
          this.animals = data;
          this.getAnimals(); 
        });
      },
      
    );
  }

}