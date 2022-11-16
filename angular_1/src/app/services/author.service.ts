import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Author } from '../models/author.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  url = 'https://localhost:7045/api/authors';

  constructor( private http: HttpClient) { }

  // methods
  findAll() { //  /api/authors
    return this.http.get<Author[]>(this.url);
  }

  findByIdWithInclude(id: number) {
    return this.http.get<Author>(`${this.url}/include/${id}`)
  }

  findById(id: number) {//  /api/authors/1
    return this.http.get<Author>(`${this.url}/${id}`)
  }

  deleteById(id: number) {//  /api/authors/1
    return this.http.delete(`${this.url}/${id}`)
  }


  create(author: Author) {
    return this.http.post<Author>(`${this.url}`, author)
 }

  update(author: Author) {
    return this.http.put<Author>(`${this.url}`, author)
  }
}
