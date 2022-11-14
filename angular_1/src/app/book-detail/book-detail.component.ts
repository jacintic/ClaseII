import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../models/book.model';
import { BookService } from '../services/book.service';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {
  book: Book | undefined;

  constructor(private activatedRoute: ActivatedRoute,
    private service: BookService,
    private router: Router) { }

  ngOnInit(): void {
    // extrae ID de url
    this.activatedRoute.paramMap.subscribe(
      {
        next: pmap => this.fetchBook(pmap.get("id")),
        error: err => console.log(err)
      }
    );
  }
  // llama al backend con esa id
  private fetchBook(id: string | number | null) {
    this.service.findByIdWithInclude(Number(id)).subscribe({
      next: bookFromBackend => this.book = bookFromBackend,
      error: err => console.log(err)
    }
    );
  }

  // delete method - deletes the entity book by id
  onDelete(id: number) {
    this.service.deleteById(id).subscribe(
      {
        next: response => this.navigateTolist(), 
        error: err => console.log(err)
      }
    );
  }

  // navigate to list
  private navigateTolist() {// /books
    this.router.navigate(["/books"]);
  }
}
