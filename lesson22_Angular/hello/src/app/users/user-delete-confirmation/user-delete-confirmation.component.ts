import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user-delete-confirmation',
  templateUrl: './user-delete-confirmation.component.html',
  styleUrl: './user-delete-confirmation.component.css'
})
export class UserDeleteConfirmationComponent {
  public email: string
  constructor(
    private router: Router,
    activateRoute: ActivatedRoute
  ) {
    this.email = activateRoute.snapshot.params['email'];
  }

  public OnReject = ()=>{
    this.router.navigate(['/users']);
  }

  public OnConfirm = () => {
    // todo: send DELETE to /user/{email}
    this.router.navigate(['/users']);
  }
}
