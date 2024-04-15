import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { BoldDirective } from '../styling-directives/bold.style-directive';

import { AppRoutingModule } from './routing/app-routing.module';

import { UserListComponent } from './users/user-list/user-list.component';
import { IUserService } from './users/user-list/user-list-service.interface';
import { UserService } from './users/user-list/user-list-service.service';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { LoginComponent } from './auth/login/loginForm.component';
import { ILoginService } from './auth/login/login.service.interface';
import { LoginService } from './auth/login/login.service';

// material:
import { MatCardModule } from '@angular/material/card';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner'; // Import MatProgressSpinnerModule
import { MatButtonModule } from '@angular/material/button';
import { UserDeleteConfirmationComponent } from './users/user-delete-confirmation/user-delete-confirmation.component';


/***
 * Inside the module, you need import the httpModule
 */
@NgModule({
  imports: [
    AppRoutingModule,

    BrowserModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
    BoldDirective,

    // material:
    MatCardModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatProgressSpinnerModule,
    MatInputModule,
    MatButtonModule,
  ],
  declarations: [
    AppComponent,
    LoginComponent,
    UserListComponent,
    UserDeleteConfirmationComponent
  ],
  bootstrap: [AppComponent],
  providers: [
    {
      provide: IUserService,
      useClass: UserService,
    },
    {
      provide: ILoginService,
      useClass: LoginService,
    },
    provideAnimationsAsync()
  ]
})
export class AppModule { }
