import { Component } from '@angular/core';
import { LocalService } from '../../services/localService';
import { Animal } from '../../models/animal';
import { AnimalService } from '../../services/animalService';

@Component({
  selector: 'app-animal',
  templateUrl: './animal.component.html',
  styleUrl: './animal.component.scss'
})
export class AnimalComponent {
  animals: Animal[] = [];
  constructor(private animalService: AnimalService, private localService: LocalService) { }

  ngOnInit(): void {
    this.getAnimals();
    
  }

  getAnimals(): void {
    this.animalService.getAnimals()
      .subscribe(animals => this.animals = animals);
  }

   


}
