import { Component, OnInit } from '@angular/core';
import { Book } from '../models/book.model';
import { BookService } from '../services/book.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  books: Book[] = [];

  columnNames: string[] = ["id", "isbn", "title", "releaseYear", "price", "actions"];

  constructor(private service: BookService) { }

  ngOnInit(): void {
    this.findAll()
  }
  private findAll() {
    this.service.findAll().subscribe(
      {
        next: books => this.books = books,
        error: err => console.log(err)
      }
    );
  }
  onDelete(id: number) {
    this.service.deleteById(id).subscribe(
      {
        next: response => this.findAll(),
        error: err => console.log(err)
      }
    );
  }
}
