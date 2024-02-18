import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { UserModel } from "../models/user";

@Injectable({providedIn : "root"})
export class UserService{

    constructor(private client: HttpClient){}

    register(user: UserModel): Observable<string>
    {
        return this.client.post("api/register", user, {responseType:"text"});
    }

    login(user: UserModel): Observable<string>{
        return this.client.post("api/login", user, {responseType:"text"});
    }
}