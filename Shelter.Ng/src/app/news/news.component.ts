import { Component } from '@angular/core';
import { LocalService } from '../../services/localService';
import { News } from '../../models/news';
import { NewsService } from '../../services/newsService';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrl: './news.component.scss'
})
export class NewsComponent{
  news: News[] = [];
  constructor(private newsService: NewsService, private localService: LocalService) { }

  ngOnInit(): void {
    this.getNews();
    
  }

  getNews(): void {
    this.newsService.getNews()
      .subscribe(news => this.news = news);
  }

   


}

