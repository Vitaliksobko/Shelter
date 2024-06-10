import { Component } from '@angular/core';
import { AdminService } from '../../../../services/adminService';
import { animalCreateModel } from '../../../../models/animalCreateModel';

@Component({
  selector: 'app-animal-create',
  templateUrl: './animal-create.component.html',
  styleUrl: './animal-create.component.scss'
})
export class AnimalCreateComponent  {
  constructor(private adminService: AdminService
  ) { }

  animal: animalCreateModel = new animalCreateModel();
  formData = new FormData();
  name : string = '';
  description : string = '';
  age : number = 0;
  breed : string = '';
  image: string | null = '';
  selectedFile: File | null = null;



  selectedFiles: File[] = [];

onCreate() {
  this.formData = new FormData();
  this.formData.append("Name", this.animal.name);
  this.formData.append("Description", this.animal.description);
  this.formData.append("Age", this.animal.age.toString());
  this.formData.append("Breed", this.animal.breed);

  if (this.selectedFiles.length > 0) {
    for (let i = 0; i < this.selectedFiles.length; i++) {
      this.formData.append('Images', this.selectedFiles[i]);
    }
  }

  this.adminService.createAnimal(this.formData).subscribe(
    () => {
      console.log("Created");
    },
    (error) => {
      console.error(error);
    }
  );
}

onFileChange(event: any) {
  this.selectedFiles = event.target.files;
}
}