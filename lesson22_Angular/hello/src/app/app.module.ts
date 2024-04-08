import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { BoldDirective } from '../styling-directives/bold.style-directive';
import { RouterOutlet } from '@angular/router';

import { UserListComponent } from './users/user-list/user-list.component';
import { IUserService } from './users/user-list/user-list-service.interface';
import { UserService } from './users/user-list/user-list-service.service';

/***
 * Inside the module, you need import the httpModule
 */
@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
    RouterOutlet,
    BoldDirective,
  ],
  declarations: [AppComponent, UserListComponent],
  bootstrap: [AppComponent],
  providers: [
    {
      provide: IUserService,
      useClass: UserService,
    }
  ]
})
export class AppModule { }
