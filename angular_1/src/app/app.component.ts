import { Component } from '@angular/core';

export interface Book
{
  id: number;
  title: string;
  author: string;
  price: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  // attr
  title: string = 'angular_1';
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
  // constructor
  // methods
  hello()
  {
    this.title = "Titulo cambiado desde un boton"
  }
}
