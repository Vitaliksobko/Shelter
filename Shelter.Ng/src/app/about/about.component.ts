import { Component } from '@angular/core';
import { Question } from '../../models/question';
import { QuestionService } from '../../services/questionService';
import { LocalService } from '../../services/localService';
import { User } from '../../models/user';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss'] // Corrected from styleUrl to styleUrls
})
export class AboutComponent {
  question: Question = new Question();
  formData = new FormData();
  user?: User;

  constructor(private questionService: QuestionService, private localService: LocalService) { }

  onCreate() {
    const userId = this.localService.get(LocalService.AuthTokenName);
    this.formData = new FormData();
    this.formData.append('Email', this.question.email);
    this.formData.append('PhoneNumber', this.question.phoneNumber);
    this.formData.append('FirstName', this.question.firstName);
    this.formData.append('SecondName', this.question.secondName);
    this.formData.append('UserQuestion', this.question.userQuestion);
    this.formData.append('UserId', userId); // Using userId obtained from localService

    this.questionService.createQuestion(this.formData).subscribe(
      () => {
        alert("Питання відправлене");
        this.clearForm();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  clearForm() {
    this.question = new Question();
  }
}