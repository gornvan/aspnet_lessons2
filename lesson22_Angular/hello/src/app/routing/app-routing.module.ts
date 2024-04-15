import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from "../auth/login/loginForm.component";
import { UserListComponent } from "../users/user-list/user-list.component";
import { UserDeleteConfirmationComponent } from "../users/user-delete-confirmation/user-delete-confirmation.component";

export const appRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'users',
    children: [
      { path: '',  component: UserListComponent },
      { path: 'details', redirectTo: '/users/' }, // todo create user details page
      { path: 'edit', redirectTo: '/users/' },  // todo create user editing page
      { path: 'delete/:email', component: UserDeleteConfirmationComponent },  // todo create user editing page
    ]
  },
  { path: '**', redirectTo: 'users' },
  //{ path: '**', component: PageNotFoundComponent } // we can create another component for NotFound error
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes,
      {
        enableTracing: false, // <-- debugging purposes only
      }
    )
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
