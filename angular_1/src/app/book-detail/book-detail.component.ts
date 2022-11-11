import { Component, OnInit } from '@angular/core';
import { Book } from '../models/book.model';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent implements OnInit {
  book: Book = {
    id: 1,
    title: 'Angular',
    author: 'John Doe',
    price: 9.99,
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus eu placerat magna, vitae dignissim ante. Aenean vel tellus libero. Fusce vulputate a odio et efficitur. Vestibulum id dignissim ligula. Nulla mollis ac massa vel viverra. Etiam tempus tortor quis massa pretium sollicitudin. Sed congue lobortis ante nec fermentum. Fusce faucibus purus libero, vel cursus leo vestibulum in. Cras lacinia risus in ultricies molestie.',
  }

  constructor() { }

  ngOnInit(): void {
  }

}
