import { of } from "rxjs";
import { UserBriefModel } from "../../models/identity/UserBriefModel";
import { IUserService } from "../../app/users/user-list/user-list-service.interface";

const mockUser: UserBriefModel = {
    Email: "e@d.com", FirstName: 'Mock', LastName: 'Object', Role: 4, FullName: "Mock Object"
};
const mockUsersCollection = [mockUser];

export class UserServiceMock implements IUserService {
    public getUsers() {
        return of(mockUsersCollection);
    }
}