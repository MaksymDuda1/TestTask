import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AlgorithInfoModel } from "../models/algorithInfo";

@Injectable({providedIn:"root"})
export class algorithInfoService{
    constructor(private client: HttpClient){

    }

    getAlgorithmInfo(): Observable<AlgorithInfoModel>{
        return this.client.get<AlgorithInfoModel>("api/algorithInfo")
    }

    updateAlgorithmInfo(data: AlgorithInfoModel): Observable<any>{
        return this.client.put<AlgorithInfoModel>("api/algorithInfo", data);
    }
}