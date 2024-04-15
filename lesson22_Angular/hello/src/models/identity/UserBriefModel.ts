import { UserRoleEnum } from "./RoleEnum";

export class UserBriefModel{
    public static FullName(user: UserBriefModel): string {
        return  user.FirstName + ' ' + user.LastName;
    }

    constructor(
        public Email: string,
        public FirstName: string,
        public LastName: string,
        public Role: UserRoleEnum,
        public FullName: string,
    )
    {
    }
}