import { Component, EventEmitter, Output } from '@angular/core';
import { NewsService } from '../../../../services/newsService';
import { NewsCreateModel } from '../../../../models/newsCreateModel';

@Component({
  selector: 'app-create-news',
  templateUrl: './create-news.component.html',
  styleUrl: './create-news.component.scss'
})
export class CreateNewsComponent  {
  @Output() newsCreated = new EventEmitter<void>();
  constructor(private newsService: NewsService
  ) { }

  news: NewsCreateModel = new NewsCreateModel();
  formData = new FormData();
  title : string = '';
  content : string = '';
  author : string = '';
  summary : string = '';
  image: string | null = '';
  selectedFile: File | null = null;



  
  onCreate() {
    if (!this.news.title || !this.news.author || !this.news.summary || !this.news.content) {
      alert("Please fill in all fields.");
      return;
    }
    if (!this.selectedFile) {
      alert("Choose a photo");
      return
    }
    this.formData = new FormData();
    this.formData.append("Title", this.news.title);
    this.formData.append("Content", this.news.content);
    this.formData.append("Summary", this.news.summary);
    this.formData.append("Author", this.news.author);
    
    if (this.selectedFile) 
      this.formData.append('Image', this.selectedFile);

    
  
  
    this.newsService.createNews(this.formData).subscribe(
      () => {
        console.log("Created")
        this.newsCreated.emit();
      },
     
    );
  }

  onFileChange(event: any) {
    this.selectedFile = event.target.files[0];
  }
}