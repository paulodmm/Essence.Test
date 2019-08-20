import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
//import { AmigoService } from '../../services/AmigoService.service'

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html',
    //providers: [AmigoService]
})
export class FetchDataComponent {
    public amigosList: AmigoData[] | undefined;

    //constructor(public http: Http, @Inject('BASE_URL') baseUrl: string, private _amigoService: AmigoService) {
    constructor(public http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.getAll();
    }
    getAll() {
        //this._amigoService.GetAll().subscribe(
        //    data => this.amigosList = data
        //)

        this.http.get('http://localhost:61792/api/Amigo/GetAll').subscribe(result => {
            this.amigosList = result.json();
        });
    }
    //AmigosProximos(id: number) {
    //    var ans = confirm("Do you want to delete customer with Id: " + id);
    //    if (ans) {
    //        this._amigoService.AmigosProximos(id).subscribe((data) => {
    //            this.getAll();
    //        }, error => console.error(error))
    //    }
    //}
    //Add(form: any) {
    //    this._amigoService.Add(form).subscribe(
    //        result => {
    //            this.getAll();
    //        },
    //        error => console.error(error)
    //    );
    //}


    //getAll() {
    //    this._amigoService.GetAll().subscribe(
    //        data => this.amigosList = data
    //    )
    //}

    //AmigosProximos(id: number) {
    //    var ans = confirm("Do you want to delete customer with Id: " + id);
    //    if (ans) {
    //        this._amigoService.AmigosProximos(id).subscribe((data) => {
    //            this.getAll();
    //        }, error => console.error(error))
    //    }
    //}
    //Add(form: any) {
    //    this._amigoService.Add(form).subscribe(
    //        result => {
    //            this.getAll();
    //        },
    //        error => console.error(error)
    //    );
    //}
}


interface AmigoData {
    AmigoId: number;
    Nome: string;
    Latitude: number;
    Longitude: number;
    Distancia: number;
}