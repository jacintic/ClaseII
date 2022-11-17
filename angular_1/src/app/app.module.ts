import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';

// Http
import { HttpClientModule } from '@angular/common/http';

// material design modules
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input'
import { MatSelectModule } from '@angular/material/select'
import { MatButtonToggleModule } from '@angular/material/button-toggle'
import { MatListModule } from '@angular/material/list'
import { ReactiveFormsModule } from '@angular/forms'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// components 
import { BookListComponent } from './book-list/book-list.component';
import { BookDetailComponent } from './book-detail/book-detail.component';
import { RouterModule } from '@angular/router';
import { BookFormComponent } from './book-form/book-form.component'
import { AuthorListComponent } from './author-list/author-list.component'
import { AuthorDetailComponent } from './author-detail/author-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    BookListComponent,
    BookDetailComponent,
    BookFormComponent,
    AuthorListComponent,
    AuthorDetailComponent
  ],
  imports: [
    // material design
    MatButtonModule,
    MatTableModule,
    MatIconModule,
    MatCardModule,
    MatDividerModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonToggleModule,
    MatListModule,
    // angular
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'books', pathMatch: 'full'},
      { path: 'books', component: BookListComponent },
      { path: 'books/:id/detail', component: BookDetailComponent },
      { path: 'books/new', component: BookFormComponent },
      { path: 'books/:id/edit', component: BookFormComponent },
      { path: 'authors', component: AuthorListComponent },
      { path: 'authors/:id/detail', component: AuthorDetailComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
