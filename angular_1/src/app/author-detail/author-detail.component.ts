import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../models/book.model';
import { BookService } from '../services/book.service';
import { Author } from '../models/author.model';
import { AuthorService } from '../services/author.service';

@Component({
  selector: 'app-author-detail',
  templateUrl: './author-detail.component.html',
  styleUrls: ['./author-detail.component.css']
})
export class AuthorDetailComponent implements OnInit {
  author: Author | undefined;
  books: Book[] = [];

  constructor(private activatedRoute: ActivatedRoute,
    private authorService: AuthorService,
    private bookService: BookService,
    private router: Router) { }

  ngOnInit(): void {
    // extrae ID de url
    this.activatedRoute.paramMap.subscribe(
      {
        next: pmap => {
          // recuperar id
          const id = pmap.get("id")
          // recuperar autor
          this.fetchAuthor(id)
          this.fetchAuthorBooks(id)
        },
        error: err => console.log(err)
      }
    );
  }
    

  private fetchAuthor(id: string | number | null) {
    this.authorService.findByIdWithInclude(Number(id)).subscribe({
      next: authFromBackend => this.author = authFromBackend,
      error: err => console.log(err)
    }
    );
  }

  fetchAuthorBooks(id: string | null) {
    this.bookService.findByAuthorId(Number(id)).subscribe({
      next: booksFromBackend => this.books = booksFromBackend,
      error: err => console.log(err)
    })
  }

  // delete method - deletes the entity book by id
  onDelete(id: number) {
    this.authorService.deleteById(id).subscribe(
      {
        next: response => this.navigateTolist(), 
        error: err => console.log(err)
      }
    );
  }

  // navigate to list
  private navigateTolist() {// /books
    this.router.navigate(["/authors"]);
  }
}
