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

  columnNames: string[] = ["id", "title", "author", "price", "actions"];

  constructor(private service: BookService) { }

  ngOnInit(): void {
    this.service.findAll().subscribe(
      {
        next: books => this.books = books,
        error: err => console.log(err)
      }
    );
  }

}
/*
  {
    id: 1,
    title: "The Lord of the Rings",
    author: "Tolkien",
    price: 100
  },
  {
    id: 2,
    title: ".NET fundamentals",
    author: "John Smith",
    price: 54.30
  },
  {
    id: 3,
    title: "C# Definitive Guide",
    author: "Paco Jhonson",
    price: 35.50
  }
];*/
