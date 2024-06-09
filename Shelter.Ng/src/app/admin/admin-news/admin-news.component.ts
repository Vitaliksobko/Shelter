import { Component, OnInit, ViewChild } from '@angular/core';
import { News } from '../../../models/news';
import { NewsService } from '../../../services/newsService';
import { LocalService } from '../../../services/localService';
import { CreateNewsComponent } from './create-news/create-news.component';

@Component({
  selector: 'app-admin-news',
  templateUrl: './admin-news.component.html',
  styleUrl: './admin-news.component.scss'
})
export class AdminNewsComponent  implements OnInit{
  @ViewChild(CreateNewsComponent) newsCreateComponent!: CreateNewsComponent;
  news: News[] = [];
  errorMessage: string = '';
  constructor(private newsService : NewsService, private localService: LocalService) { }

  ngOnInit(): void {
    this.getNews();
  }
  ngAfterViewInit(): void {
    this.newsCreateComponent.newsCreated.subscribe(() => {
      this.getNews(); 
    });
  }

  getNews(): void {
    this.newsService.getNews()
      .subscribe(news => this.news = news);
  }

  delete(id: string) {
    this.newsService.deleteNews(id).subscribe(
      () => {
        console.log('product deleted successfully');
        this.newsService.getNews().subscribe(data => {
          this.news = data;
        });
      },
      
    );
  }

}
