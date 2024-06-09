import { Component } from '@angular/core';
import { Question } from '../../models/question';
import { QuestionService } from '../../services/questionService';
import { LocalService } from '../../services/localService';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrl: './about.component.scss'
})
export class AboutComponent {
  question: Question = new Question();
  formData = new FormData();
  email: string = '';
  phoneNumber: string = '';
  firstName: string = '';
  secondName: string = '';
  userQuestion: string = '';

  constructor(private questionService: QuestionService, private localService: LocalService) { }

  onCreate() {
    const userId = this.localService.get(LocalService.AuthTokenName);
    this.formData = new FormData();
    this.formData.append('Email', this.question.email);
    this.formData.append('PhoneNumber', this.question.phoneNumber);
    this.formData.append('FirstName', this.question.firstName);
    this.formData.append('SecondName', this.question.secondName);
    this.formData.append('UserQuestion', this.question.userQuestion);

    this.questionService.createQuestion(userId, this.formData).subscribe(
      () => {
        console.log("Created");
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
