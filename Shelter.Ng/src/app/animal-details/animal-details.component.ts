import { Component, OnInit } from '@angular/core';
import { Animal } from '../../models/animal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';  // Import Validators for form validation
import { ActivatedRoute, Router } from '@angular/router';
import { AnimalService } from '../../services/animalService';
import { Booking } from '../../models/booking';
import { LocalService } from '../../services/localService';
import { AnimalStatus } from '../../enum/animalStatus';

@Component({
  selector: 'app-animal-details',
  templateUrl: './animal-details.component.html',
  styleUrls: ['./animal-details.component.scss']
})
export class AnimalDetailsComponent implements OnInit {
  animal!: Animal;
  bookingForm!: FormGroup;
  animalStatus = AnimalStatus;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private animalService: AnimalService,
    private fb: FormBuilder,
    private localService: LocalService
  ) { }

  ngOnInit(): void {
    const animalId = this.route.snapshot.paramMap.get('id');
    if (animalId) {
      this.animalService.getAnimal(animalId).subscribe(animal => {
        this.animal = animal;
      });
    }
    this.bookingForm = this.fb.group({
      date: ['', Validators.required],  // Add validators for required fields
      startTime: ['', Validators.required],
      endTime: ['', Validators.required]
    });
  }

  adoptAnimal(): void {
    if (this.animal.status === AnimalStatus.Available) {
      this.animalService.adoptAnimal(this.animal.animalId).subscribe(
        () => {
          this.animal.status = AnimalStatus.InProcess;
          alert('Check your email address');
        },
        (error) => {
          console.error('Error when adopting an animal:', error);
          alert('Error when adopting an animal');
        }
      );
    } else {
      alert('This animal is not available for adoption');
    }
  }

  onSubmit(): void {
    if (this.animal.status !== AnimalStatus.Available) {
      alert('Booking is not allowed for this animal');
      return;
    }
  
    const id = this.localService.get(LocalService.AuthTokenName);
    const { date, startTime, endTime } = this.bookingForm.value;
  
    const today = new Date();
    const selectedDate = new Date(date);
  
    // Check if selected date is today or in the past
    if (selectedDate <= today) {
      alert('Please select a future date for the walk.');
      return;
    }
  
    const startDateTime = new Date(date);
    const [startHours, startMinutes] = startTime.split(':');
    startDateTime.setHours(startHours, startMinutes);
  
    const endDateTime = new Date(date);
    const [endHours, endMinutes] = endTime.split(':');
    endDateTime.setHours(endHours, endMinutes);
  
    // Check if end time is at least 1 hour after start time
    const minDuration = 60 * 60 * 1000; // 1 hour in milliseconds
    if (endDateTime.getTime() <= startDateTime.getTime() + minDuration) {
      alert('The walk duration must be at least 1 hour.');
      return;
    }
  
    const booking: Booking = {
      animalId: this.animal.animalId,
      userId: id,
      startTime: startDateTime,
      endTime: endDateTime
    };
  
    this.animalService.bookAnimal(this.animal.animalId, booking).subscribe(
      () => {
        const message = `${this.animal.name} is waiting for you.`;
        alert(message);
      },
      (error) => {
        console.error('Error when booking:', error);
        if (error.status === 400) {
          alert('Selected time overlaps with existing bookings. Please choose another time.');
        } else {
          alert('An unexpected error occurred. Please try again later.');
        }
      }
    );
  }

  isAvailable(): boolean {
    return this.animal.status === AnimalStatus.Available;
  }
}
