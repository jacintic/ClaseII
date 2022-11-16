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
  book: Book | undefined;

  constructor(
    private bookService: BookService,
    private router: Router,
    private activatedRoute: ActivatedRoute  ) { }

  ngOnInit(): void {
    // extract ID from ulr
    this.activatedRoute.paramMap.subscribe({
      next: pmap => {
        let id = pmap.get("id");
        // if the id is set
          // fetch the book with this id
        if (id) 
          this.fetchBookWithInc(Number(id)) 
      }
    })
  }

  createFormGroup() {
    return new FormGroup({

      id: new FormControl({ value: null, disabled: true }),
      isbn: new FormControl(),
      title: new FormControl(),
      description: new FormControl(),
      releaseYear: new FormControl(),
      price: new FormControl(),
      // TODO - asociaciones author y categories

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
  // llama al backend con esa id
  private fetchBookWithInc(id: string | number | null) {
    this.bookService.findByIdWithInclude(Number(id)).subscribe({
      /*next: bookFromBackend => this.editForm.reset(bookFromBackend),*///this.book = bookFromBackend,
      next: bookFromBackend => {
        this.editForm.reset({
          id: { value: bookFromBackend.id, disabled: true },
          title: bookFromBackend.title,
          price: bookFromBackend.price,
          description: bookFromBackend.description,
          isbn: bookFromBackend.isbn,
          releaseYear: bookFromBackend.releaseYear ,
        } as any)
      },
      error: err => console.log(err)
    }
    );
  }
}
