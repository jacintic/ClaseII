import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../models/book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  url = 'https://localhost:7045/api/books';

  constructor( private http: HttpClient) { }

  // methods
  findAll() { //  /api/books
    return this.http.get<Book[]>(this.url);
  }

  findByIdWithInclude(id: number) {
    return this.http.get<Book>(`${this.url}/include/${id}`)
  }

  findById(id: number) {//  /api/books/1
    return this.http.get<Book>(`${this.url}/${id}`)
  }

  deleteById(id: number) {//  /api/books/1
    return this.http.delete(`${this.url}/${id}`)
  }


 /* create() {

  }*/
}
