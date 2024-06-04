import { Component, OnInit } from '@angular/core';
import { Animal } from '../../models/animal';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AnimalService } from '../../services/animalService';
import { Booking } from '../../models/booking';
import { LocalService } from '../../services/localService';

@Component({
  selector: 'app-animal-details',
  templateUrl: './animal-details.component.html',
  styleUrls: ['./animal-details.component.scss'] // змінено на styleUrls
})
export class AnimalDetailsComponent implements OnInit {
  animal!: Animal;
  bookingForm!: FormGroup;

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
      date: [''],
      startTime: [''],
      endTime: ['']
    });
  }

  onSubmit(): void {
    const id = this.localService.get(LocalService.AuthTokenName);
    const { date, startTime, endTime } = this.bookingForm.value;

    const startDateTime = new Date(date);
    const [startHours, startMinutes] = startTime.split(':');
    startDateTime.setUTCHours(startHours, startMinutes);

    const endDateTime = new Date(date);
    const [endHours, endMinutes] = endTime.split(':');
    endDateTime.setUTCHours(endHours, endMinutes);

    const booking: Booking = {
      animalId: this.animal.animalId,
      userId: id,
      startTime: startDateTime,
      endTime: endDateTime
    };

    this.animalService.bookAnimal(this.animal.animalId, booking).subscribe(() => {
      alert('Бронювання успішне');
    });
  }
}
