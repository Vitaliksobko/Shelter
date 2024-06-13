import { Component, Input } from '@angular/core';
import { News } from '../../../models/news';
import { ActivatedRoute } from '@angular/router';
import { NewsService } from '../../../services/newsService';

@Component({
  selector: 'app-new-detail',
  templateUrl: './new-detail.component.html',
  styleUrl: './new-detail.component.scss'
})
export class NewDetailComponent {

  constructor(
    private router: ActivatedRoute,
    private newsService: NewsService,)
    {
      this.router.paramMap.subscribe((params) => 
      {
        let id = params.get('id');

        if(id != null){
          this.newsService.getNew(id).subscribe(
            data => this.news = data,
            errorResponse => this.errorMessage = errorResponse.error
          );
        }
      })
    }

    news: News = new News();
    errorMessage: string  = '';
    

}
