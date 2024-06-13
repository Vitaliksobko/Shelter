import { Component, OnInit, ViewChild } from '@angular/core';
import { Animal } from '../../../models/animal';
import { AdminService } from '../../../services/adminService';
import { LocalService } from '../../../services/localService';
import { AnimalCreateComponent } from './animal-create/animal-create.component';
import { AnimalStatus } from '../../../enum/animalStatus';

@Component({
  selector: 'app-admin-animal',
  templateUrl: './admin-animal.component.html',
  styleUrl: './admin-animal.component.scss'
})
export class AdminAnimalComponent implements OnInit {
  @ViewChild(AnimalCreateComponent) animalCreateComponent!: AnimalCreateComponent;
  animals: Animal[] = [];
  errorMessage: string = '';
  animalStatus = AnimalStatus;

  constructor(private adminService: AdminService, private localService: LocalService) { }

  ngOnInit(): void {
    this.getAnimals();
  }

  ngAfterViewInit(): void {
    this.animalCreateComponent.animalCreated.subscribe(() => {
      this.getAnimals();
    });
  }

  getAnimals(): void {
    this.adminService.getAnimals().subscribe(animals => this.animals = animals);
  }

  delete(id: string): void {
    this.adminService.deleteAnimal(id).subscribe(
      () => {
        console.log('Animal deleted successfully');
        this.getAnimals();
      },
      error => this.errorMessage = error
    );
  }

  confirm(id: string): void {
    this.adminService.adoptConfirm(id).subscribe(
      () => {
        console.log('Animal confirmed successfully');
        this.getAnimals();
      },
      error => this.errorMessage = error
    );
  }
  
  reject(id: string): void {
    this.adminService.adoptReject(id).subscribe(
      () => {
        console.log('Animal rejected successfully');
        this.getAnimals();
      },
      error => this.errorMessage = error
    );
  }
  
}
