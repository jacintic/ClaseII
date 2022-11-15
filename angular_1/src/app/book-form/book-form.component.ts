import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Book } from '../models/book.model';
import { BookService } from '../services/book.service';
import { ActivatedRoute, Router } from '@angular/router';



@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent implements OnInit {

  editForm = this.createFormGroup();
  error: boolean = false;

  constructor(
    private bookService: BookService,
    private router: Router  ) { }

  ngOnInit(): void {
  }

  createFormGroup() {
    return new FormGroup({

      //id: new FormControl(),
      isbn: new FormControl(),
      title: new FormControl(),
      description: new FormControl(),
      releaseYear: new FormControl(),
      price: new FormControl(),

    });
  }

  save() {
    // extraer los datos del formulario y enviarlos al backend cond BookService.create POST
    let book = {
      isbn: this.editForm.get("isbn")?.value,
      title: this.editForm.get("title")?.value,
      description: this.editForm.get("description")?.value,
      releaseYear: this.editForm.get("releaseYear")?.value,
      price: this.editForm.get("price")?.value
    } as Book
    console.log(book)
    // save to DB
    this.bookService.create(book).subscribe(
      {
        next: response => this.navigateToList(),
        error: err => this.showError(err)
      }
    );
  }

  private navigateToList() {
    this.router.navigate(["/books"]);
  }

  private showError(err: any): void {
    this.error = true
    console.log(err)
  }
}
