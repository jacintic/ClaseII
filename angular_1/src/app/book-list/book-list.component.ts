import { Component, OnInit } from '@angular/core';
import { Book } from '../models/book.model';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  books: Book[] = [
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
  ];
  columnNames: string[] = ["id", "title", "author", "price", "actions"];

  constructor() { }

  ngOnInit(): void {
  }

}
