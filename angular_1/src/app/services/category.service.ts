import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  url = 'https://localhost:7045/api/categories';

  constructor( private http: HttpClient) { }

  // methods
  findAll() { //  /api/authors
    return this.http.get<Category[]>(this.url);
  }

  findByIdWithInclude(id: number) {
    return this.http.get<Category>(`${this.url}/include/${id}`)
  }

  findById(id: number) {//  /api/categories/1
    return this.http.get<Category>(`${this.url}/${id}`)
  }

  deleteById(id: number) {//  /api/categories/1
    return this.http.delete(`${this.url}/${id}`)
  }


  create(category: Category) {
    return this.http.post<Category>(`${this.url}`, category)
 }

  update(category: Category) {
    return this.http.put<Category>(`${this.url}`, category)
  }
}
