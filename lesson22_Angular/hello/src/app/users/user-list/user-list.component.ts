import { Component, OnInit } from '@angular/core';
import { UserBriefModel } from '../../../models/identity/UserBriefModel';
import { IUserService } from './user-list-service.interface';

@Component({
    selector: 'app-user-list',
    templateUrl: './user-list.component.html',
})
export class UserListComponent implements OnInit {
    users: UserBriefModel[] = [];

    constructor(private userService: IUserService) { }

    ngOnInit(): void {
        this.loadUsers();
    }

    loadUsers(): void {
        this.userService.getUsers().subscribe(users => {
            this.users = users.map(
                (u) => {
                    u.FullName = UserBriefModel.FullName(u);
                    return u;
                });
            const _document: any = document;
            _document.users = users;
        });
    }
}
