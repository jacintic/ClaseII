import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { BookService } from '../services/book.service';
import { Author } from '../models/author.model';
import { AuthorService } from '../services/author.service';
import { Category } from '../models/category.model';
import { CategoryService } from '../services/category.service';
import { ActivatedRoute, Router } from '@angular/router';





@Component({
  selector: 'category-book-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.css']
})
export class CategoryFormComponent implements OnInit {

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
        if (id) {
          this.fetchCategory(Number(id));
          this.isEdit = true;
        } 
           
      }
    })
  }
  createFormGroup() {
    return new FormGroup({

      id: new FormControl({ value: null, disabled: true }),
      name: new FormControl(),
      minAge: new FormControl(),
      
    });
  }

  save() {
    // extraer los datos del formulario y enviarlos al backend cond BookService.create POST
    let category = {
      name: this.editForm.get("name")?.value,
      minAge: this.editForm.get("minAge")?.value,
    } as any
    console.log(category)
    let id = this.editForm.get("id")?.value
    // update
    if (id) {
      category.id = id;
      this.categoryService.update(category).subscribe(
        {
          next: response => this.navigateToList(),
          error: err => this.showError(err)
        }
      );
      // save
    } else {
      this.categoryService.create(category).subscribe(
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
  private fetchCategory(id: string | number | null) {
    this.categoryService.findById(Number(id)).subscribe({
      /*next: bookFromBackend => this.editForm.reset(bookFromBackend),*///this.book = bookFromBackend,
      next: categoryFromBackend => {
        this.editForm.reset({
          id: { value: categoryFromBackend.id, disabled: true },
          name: categoryFromBackend.name,
          minAge: categoryFromBackend.minAge,
          // association
        } as any)
      },
      error: err => console.log(err)
    }
    );
  }
}
