import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';


@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent implements OnInit {

  editForm = this.createFormGroup();

  constructor() { }

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
    console.log(this.editForm.get("title")?.value)
  }
}
