import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { ILoginService } from './login.service.interface';

@Injectable({
    providedIn: 'root'
})
export class LoginService implements ILoginService {

    private readonly baseUrl: string = environment.API_URL;

    constructor(private http: HttpClient) { }

    public LogIn(Email: string, Password: string): Promise<void> {
        const url = `${this.baseUrl}/api/Login`;

        return new Promise<void>((resolve, reject) => {
            this.http.post(url, { Email, Password })
            .subscribe({
                complete: ()=>{
                    resolve()
                },
                error: (err)=>{
                    reject(err)
                },
            });
        });
    }
}
