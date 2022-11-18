import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { BookService } from '../services/book.service';
import { Author } from '../models/author.model';
import { AuthorService } from '../services/author.service';
import { Category } from '../models/category.model';
import { CategoryService } from '../services/category.service';
import { ActivatedRoute, Router } from '@angular/router';





@Component({
  selector: 'author-book-form',
  templateUrl: './author-form.component.html',
  styleUrls: ['./author-form.component.css']
})
export class AuthorFormComponent implements OnInit {

  editForm = this.createFormGroup()
  error: boolean = false
  isEdit: boolean = false


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
        if (id) {
          this.fetchAuthorWithInc(Number(id));
          this.isEdit = true;
        } 
           
      }
    })
  }
  createFormGroup() {
    return new FormGroup({

      id: new FormControl({ value: null, disabled: true }),
      fullName: new FormControl(),
      email: new FormControl(),
      salary: new FormControl(),
      birthDate: new FormControl(),
      // associations
      idAddress: new FormControl({ value: null, disabled: true }),
      street: new FormControl(),
      city: new FormControl(),
      
    });
  }

  save() {
    let address = {
      city: this.editForm.get("city")?.value,
      street: this.editForm.get("street")?.value,
    }
    // extraer los datos del formulario y enviarlos al backend cond BookService.create POST
    let author = {
      fullName: this.editForm.get("fullName")?.value,
      salary: this.editForm.get("salary")?.value,
      email: this.editForm.get("email")?.value,
      birthDate: this.editForm.get("birthDate")?.value,
      address: address,
    } as any
    console.log(author)
    let id = this.editForm.get("id")?.value
    // update
    if (id) {
      author.id = id;
      author.address.id = this.editForm.get("idAddress")?.value
      this.authorService.update(author).subscribe(
        {
          next: response => this.navigateToList(),
          error: err => this.showError(err)
        }
      );
      // save
    } else {
      this.authorService.create(author).subscribe(
        {
          next: response => this.navigateToList(),
          error: err => this.showError(err)
        }
      );
    }
  }

  private navigateToList() {
    this.router.navigate(["/authors"]);
  }

  private showError(err: any): void {
    this.error = true
    console.log(err)
  }
  // llama al backend con esa id
  private fetchAuthorWithInc(id: string | number | null) {
    this.authorService.findByIdWithInclude(Number(id)).subscribe({
      /*next: bookFromBackend => this.editForm.reset(bookFromBackend),*///this.book = bookFromBackend,
      next: authorFromBackend => {
        this.editForm.reset({
          id: { value: authorFromBackend.id, disabled: true },
          fullName: authorFromBackend.fullName,
          email: authorFromBackend.email,
          salary: authorFromBackend.salary,
          price: authorFromBackend.email,
          birthDate: authorFromBackend.birthDate,
          // association
          idAddress: authorFromBackend?.address?.id,
          street: authorFromBackend?.address?.street,
          city: authorFromBackend?.address?.city,
        } as any)
      },
      error: err => console.log(err)
    }
    );
  }
}
