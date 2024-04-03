import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BoldDirective } from '../styling-directives/bold.style-directive'

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, BoldDirective],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'hello';
}
