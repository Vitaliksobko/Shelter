import { Component, EventEmitter, Output } from '@angular/core';
import { AdminService } from '../../../../services/adminService';
import { ActivatedRoute } from '@angular/router';
import { AnimalService } from '../../../../services/animalService';
import { animalUpdateModel } from '../../../../models/animalUpdateModel';

@Component({
  selector: 'app-aminal-update',
  templateUrl: './aminal-update.component.html',
  styleUrl: './aminal-update.component.scss'
})
export class AminalUpdateComponent {
  @Output() animalCreated = new EventEmitter<void>();

  constructor(
    private animalService: AnimalService,
    private route: ActivatedRoute) {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if(id != null){
         this.getById(id);
      }else{
       
      }
    })
  }

  
  animal: animalUpdateModel = new animalUpdateModel();
  formData = new FormData();
  animalId: string = '';
  name: string = '';
  age: number = 0;
  breed: string = '';
  description: string = '';
  selectedFile: File | null = null;
  
  errorMessage: string = "";
  selectedImageBase64: string | null = null;
  
  getById(id: string){
    this.animalService.getAnimal(id).subscribe(data => {
      this.animal = data;
    })
  }
  
  onUpdate() {
    this.formData = new FormData();
    this.formData.append("AnimalId", this.animal.animalId);
    this.formData.append("Name", this.animal.name);
    this.formData.append("Description", this.animal.description);
    this.formData.append("Age", this.animal.age.toString());
    this.formData.append("Breed", this.animal.breed);
  
    // Перевірка, чи this.selectedFile не є null перед додаванням до FormData
    if (this.selectedFile !== null) {
      this.formData.append('Image', this.selectedFile);
    } else {
      // Якщо нова фотографія не була обрана, відправити ту ж саму фотографію
      this.formData.append('Image', this.animal.image);
    }
  
    this.animalService.updateAnimal(this.formData).subscribe(() => {
      console.log("Updated");
      this.errorMessage = "Updated"
    },
    errorResponse => {
      this.errorMessage = errorResponse.error;
    });
  }
  

  onFileChange(event: any) {
    this.selectedFile = event.target.files[0];
    if (this.selectedFile) {
      const reader = new FileReader();
      reader.onload = () => {
        this.selectedImageBase64 = reader.result as string;
      };
      reader.readAsDataURL(this.selectedFile);
    } else {
      this.selectedImageBase64 = null;
    }
  }

}
