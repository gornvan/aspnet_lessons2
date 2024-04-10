import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserBriefModel } from '../../../models/identity/UserBriefModel';
import { IUserService } from './user-list-service.interface';
import { environment } from '../../../environments/environment.development';

@Injectable({
    providedIn: 'root'
})
export class UserService implements IUserService {

    private readonly baseUrl: string = environment.API_URL;

    constructor(private http: HttpClient) { }

    getUsers(): Observable<UserBriefModel[]> {
        const url = `${this.baseUrl}/api/User`;
        return this.http.get<UserBriefModel[]>(url, { withCredentials: true });
    }
}
