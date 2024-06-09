import { Component, EventEmitter, Output } from '@angular/core';
import { AdminService } from '../../../../services/adminService';
import { animalCreateModel } from '../../../../models/animalCreateModel';

@Component({
  selector: 'app-animal-create',
  templateUrl: './animal-create.component.html',
  styleUrls: ['./animal-create.component.scss']
})
export class AnimalCreateComponent {
  @Output() animalCreated = new EventEmitter<void>();

  animal: animalCreateModel = new animalCreateModel();
  formData = new FormData();
  selectedFile: File | null = null;

  constructor(private adminService: AdminService) { }

  onCreate() {
    if (!this.animal.name || !this.animal.breed || !this.animal.age) {
      alert("Please fill in all fields.");
      return;
    }
    if (this.animal.age < 0) {
      alert("Age cannot be a negative number.");
      return;
    }
    if (!this.selectedFile) {
      alert("Choose a photo");
      return;
    }

    this.formData = new FormData();
    this.formData.append("Name", this.animal.name);
    this.formData.append("Description", this.animal.description);
    this.formData.append("Age", this.animal.age.toString());
    this.formData.append("Breed", this.animal.breed);
    this.formData.append('Images', this.selectedFile);

    this.adminService.createAnimal(this.formData).subscribe(
      () => {
        console.log("Created");
        this.animalCreated.emit();
        this.resetForm();
      },
      (error: any) => {
        console.error("Error:", error);
        if (error.status === 400) {
          alert("Bad Request: Please check your form data.");
        } else {
          alert(`Error: ${error.message}`);
        }
      }
    );
  }

  resetForm() {
    this.animal = new animalCreateModel();
    this.selectedFile = null;
    (document.getElementById('file-upload') as HTMLInputElement).value = '';
  }

  onFileChange(event: any) {
    this.selectedFile = event.target.files[0];
  }
}
