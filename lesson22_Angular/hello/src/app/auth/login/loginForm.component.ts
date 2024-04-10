import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ILoginService } from './login.service.interface';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private snackBar: MatSnackBar,
    private loginService: ILoginService
  ) {
    this.loginForm = this.formBuilder.group({
        email: ['', [Validators.required, Validators.email]],
        password: ['', Validators.required]
      });
  }

  ngOnInit(): void {

  }

  onSubmit(): void {
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true; // show the spinner

    const { email, password } = this.loginForm.value;
    this.loginService.LogIn(email, password)
      .then(() => {
        this.router.navigate(['/users/list']);
      })
      .catch(error => {
        console.log(error);
        this.error = 'Invalid email or password.';
        this.loading = false;
        this.snackBar.open(this.error, 'Close', {
          duration: 3000
        });
      });
  }
}
