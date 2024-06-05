import { Injectable, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { Booking } from "../models/booking";
import { News } from "../models/news";

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  private apiUrl = '/api/news'; 

  constructor(private http: HttpClient) { }

  getNews(): Observable<News[]> {
    return this.http.get<News[]>(this.apiUrl);
  }

  getNew(id: string): Observable<any> {
    return this.http.get<News>('api/news/' + id);
  }

  createNews(createNews: FormData): Observable<any> {
    return this.http.post('api/news', createNews);
  }

  deleteNews(id: string): Observable<any> {
    return this.http.delete('api/news/product/'+ id);
}

}