import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from '../models/book.model';
import { BookService } from '../services/book.service';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {
  book: Book | undefined;

  constructor(private activatedRoute: ActivatedRoute, private service: BookService) { }

  ngOnInit(): void {
    // extrae ID de url
    this.activatedRoute.paramMap.subscribe(
      {
        next: pmap => this.findById(pmap.get("id")),
        error: err => console.log(err)
      }
    );
  }
  // llama al backend con esa id
  private findById(id: string | number | null) {
    this.service.findById(Number(id)).subscribe({
      next: bookFromBackend => this.book = bookFromBackend,
      error: err => console.log(err)
    }
    );
  }
}
