import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './routing/app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { BoldDirective } from '../styling-directives/bold.style-directive';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatInputModule } from '@angular/material/input';

import { AppComponent } from './app.component';
import { UserServiceMock } from '../mocksServices/users/UserServiceMock';
import { UserListComponent } from './users/user-list/user-list.component';
import { IUserService } from './users/user-list/user-list-service.interface';

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppRoutingModule,
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
        MatButtonModule,],
      declarations: [AppComponent, UserListComponent],
      providers: [{
        provide: IUserService,
        useClass: UserServiceMock,
      }],
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have the 'Fabric Market' title`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('Fabric Market');
  });
});
