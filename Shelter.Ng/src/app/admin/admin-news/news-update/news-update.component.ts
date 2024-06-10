import { Component, EventEmitter, Output } from '@angular/core';
import { AnimalService } from '../../../../services/animalService';
import { ActivatedRoute } from '@angular/router';
import { newsUpdateModel } from '../../../../models/newsUpdateModel';
import { NewsService } from '../../../../services/newsService';


@Component({
  selector: 'app-news-update',
  templateUrl: './news-update.component.html',
  styleUrl: './news-update.component.scss'
})
export class NewsUpdateComponent {
  @Output() animalCreated = new EventEmitter<void>();

  constructor(
    
    private newsService: NewsService,
    private route: ActivatedRoute) {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if(id != null){
         this.getById(id);
      }else{
        
      }
    })
  }

  
  news: newsUpdateModel = new newsUpdateModel();
  formData = new FormData();
  newsId : string = '';
  title : string = '';
  content : string = '';
  author : string = '';
  summary : string = '';
  
  selectedFile: File | null = null;
  
  errorMessage: string = "";
  selectedImageBase64: string | null = null;
  
  getById(id: string){
    this.newsService.getNew(id).subscribe(data => {
      this.news = data;
    })
  }
  
  onUpdate() {
    this.formData = new FormData();
    this.formData.append("NewsId", this.news.newsId);
    this.formData.append("Title", this.news.title);
    this.formData.append("Content", this.news.content);
    this.formData.append("Summary", this.news.summary);
    this.formData.append("Author", this.news.author);
    
  
    // Перевірка, чи this.selectedFile не є null перед додаванням до FormData
    if (this.selectedFile !== null) {
      this.formData.append('Image', this.selectedFile);
    } else {
      // Якщо нова фотографія не була обрана, відправити ту ж саму фотографію
      this.formData.append('Image', this.news.image);
    }
  
    this.newsService.updateNews(this.formData).subscribe(() => {
      console.log("Updated");
      this.errorMessage = "Updated"
    },
    errorResponse => {
      this.errorMessage = errorResponse.error;
    });
  }
  

  onFileChange(event: any) {
    this.selectedFile = event.target.files[0];
    if (this.selectedFile) {
      const reader = new FileReader();
      reader.onload = () => {
        this.selectedImageBase64 = reader.result as string;
      };
      reader.readAsDataURL(this.selectedFile);
    } else {
      this.selectedImageBase64 = null;
    }
  }

}