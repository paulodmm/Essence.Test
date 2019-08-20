import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw'


@Injectable()
export class AmigoService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = 'http://localhost:61792/'; //baseUrl;
    }
    AmigosProximos(id: number) {
        return this._http.get(this.myAppUrl + "api/Amigo/AmigosProximos/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }
    GetAll() {
        return this._http.get(this.myAppUrl + 'api/Amigo/GetAll')
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }
    Add(amigoModel: AmigoModel) {
        return this._http.post(this.myAppUrl + 'api/Amigo/Add', amigoModel)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }    
    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}

export class AmigoModel {
    AmigoId: number | undefined;
    Nome: string | undefined;
    Latitude: number | undefined;
    Longitude: number | undefined;
    Distancia: number | undefined;
}