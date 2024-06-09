import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({ providedIn: "root" })
export class QuestionService {
  constructor(private client: HttpClient) { }

  createQuestion(userId: string, createQuestion: FormData): Observable<any> {
    return this.client.post('api/question', createQuestion);
  }
}
