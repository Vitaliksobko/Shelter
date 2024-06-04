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
  errorMessage: string = '';
  inCartMap: Map<string, boolean> = new Map<string, boolean>();
  constructor(private animalService: AnimalService, private localService: LocalService) { }

  ngOnInit(): void {
    this.getProducts();
    
  }

  getProducts(): void {
    this.animalService.getProducts()
      .subscribe(animals => this.animals = animals);
  }

   


}
