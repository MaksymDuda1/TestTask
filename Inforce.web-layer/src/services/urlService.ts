import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UrlModel, UrlForShortModel, ShortenerUrl } from "../models/url";

@Injectable({providedIn:"root"})
export class UrlService{
    constructor(private client: HttpClient){

    }

    add(data: UrlForShortModel):Observable<UrlModel> {
        return this.client.post<UrlModel>("/api/urls", data);
    }

    getAll(): Observable<UrlModel[]>{
        return this.client.get<UrlModel[]>("api/urls");
    }

    getById(id: string): Observable<UrlModel>{
        return this.client.get<UrlModel>("api/urls/" + id)
    }

    deleteById(id:string){
        return this.client.delete<UrlModel>("api/urls/" + id);
    }

    deleteAll(){
        return this.client.delete("api/admin")
    }

    redirect(ulr: string){
        return this.client.get("api/" + ulr);
    }
    
}