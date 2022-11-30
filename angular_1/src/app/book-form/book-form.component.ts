import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { BookService } from '../services/book.service';
import { Author } from '../models/author.model';
import { AuthorService } from '../services/author.service';
import { Category } from '../models/category.model';
import { CategoryService } from '../services/category.service';
import { ActivatedRoute, Router } from '@angular/router';





@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent implements OnInit {

  editForm = this.createFormGroup();
  error: boolean = false;
  authors: Author[] = [];
  categories: Category[] = [];

  constructor(
    private bookService: BookService,
    private authorService: AuthorService,
    private categoryService: CategoryService,
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
    }),
      this.fetchAuthors()
      this.fetchCategories()
  }
  createFormGroup() {
    return new FormGroup({

      id: new FormControl({ value: null, disabled: true }),
      isbn: new FormControl(),
      imgUrl: new FormControl(),
      title: new FormControl(),
      description: new FormControl(),
      releaseYear: new FormControl(),
      price: new FormControl(),
      // TODO - asociacion categories
      authorId: new FormControl(),
      categories: new FormControl(),
    });
  }

  fetchAuthors() {
    this.authorService.findAll().subscribe(
      {
        next: authorsRes => this.authors = authorsRes,
        error: err => this.showError(err)
      })
  }
  fetchCategories() {
    this.categoryService.findAll().subscribe(
      {
        next: catRes => this.categories = catRes,
        error: err => this.showError(err)
      })
  }

  save() {
    // extraer los datos del formulario y enviarlos al backend cond BookService.create POST
    let book = {
      isbn: this.editForm.get("isbn")?.value,
      imgUrl: this.editForm.get("imgUrl")?.value,
      title: this.editForm.get("title")?.value,
      description: this.editForm.get("description")?.value,
      releaseYear: this.editForm.get("releaseYear")?.value,
      price: this.editForm.get("price")?.value,
      authorId: this.editForm.get("authorId")?.value,
      categories: this.categories.filter(cat => this.editForm.get("categories")?.value.includes(cat.id) ),
    } as any
    console.log(book)
    let id = this.editForm.get("id")?.value
    // save to DB
    if (id) {
      book.id = id
      this.bookService.update(book).subscribe(
        {
          next: response => this.navigateToList(),
          error: err => this.showError(err)
        }
      );
    } else {
      this.bookService.create(book).subscribe(
        {
          next: response => this.navigateToList(),
          error: err => this.showError(err)
        }
      );
    }
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
          imgUrl: bookFromBackend.imgUrl,
          price: bookFromBackend.price,
          description: bookFromBackend.description,
          isbn: bookFromBackend.isbn,
          releaseYear: bookFromBackend.releaseYear,
          authorId: bookFromBackend.authorId,
          categories: bookFromBackend.categories?.map(category => category.id)
        } as any)
      },
      error: err => console.log(err)
    }
    );
  }
}
