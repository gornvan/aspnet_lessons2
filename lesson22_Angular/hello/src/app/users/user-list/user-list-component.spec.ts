import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserListComponent } from './user-list.component';
import { IUserService } from './user-list-service.interface';

import { of } from 'rxjs';
import { UserBriefModel } from '../../../models/identity/UserBriefModel';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from '../../routing/app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { BoldDirective } from '../../../styling-directives/bold.style-directive';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatInputModule } from '@angular/material/input';

import { UserServiceMock } from '../../../mocksServices/users/UserServiceMock';

describe('UserDeleteConfirmationComponent', () => {
  let component: UserListComponent;
  let fixture: ComponentFixture<UserListComponent>;

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
      declarations: [UserListComponent],
      providers: [{
        provide: IUserService,
        useClass: UserServiceMock,
      }],
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render title "Users List"', () => {
    const fixture = TestBed.createComponent(UserListComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h2')?.textContent).toContain('Users List');
  });
});
