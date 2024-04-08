import { Observable } from "rxjs";
import { UserBriefModel } from "../../../models/identity/UserBriefModel";

export abstract class IUserService{
    abstract getUsers(): Observable<UserBriefModel[]>
};