export abstract class ILoginService {
    public abstract LogIn(username: string, password: string): Promise<void>
}