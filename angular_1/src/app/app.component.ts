import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  // attr
  title: string = 'angular_1';
  // constructor
  // methods
  hello()
  {
    this.title = "Titulo cambiado desde un boton"
  }
}
