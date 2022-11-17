import { Component, OnInit } from '@angular/core';
import { Author } from '../models/author.model';
import { AuthorService } from '../services/author.service';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.css']
})
export class AuthorListComponent implements OnInit {

  authors: Author[] = [];

  columnNames: string[] = ["id", "fullName", "email", "salary", "actions"];

  constructor(private service: AuthorService) { }

  ngOnInit(): void {
    this.findAll()
  }
  private findAll() {
    this.service.findAll().subscribe(
      {
        next: authors => this.authors = authors,
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
