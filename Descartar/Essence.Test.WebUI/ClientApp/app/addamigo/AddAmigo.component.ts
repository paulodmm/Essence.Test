import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router'; 
import { AmigoService } from '../services/AmigoService.service'

@Component({
    selector: 'AddAmigo',
    templateUrl: './AddAmigo.component.html'
})

export class AddAmigoComponent {
    public amigosList: AmigoData[] | undefined;
    constructor(public http: Http, private _router: Router, private _amigoService: AmigoService) {
        this.getAll();
    }
    getAll() {
        this._amigoService.GetAll().subscribe(
            data => this.amigosList = data
        )
    }
    AmigosProximos(id: number) {
        var ans = confirm("Do you want to delete customer with Id: " + id);
        if (ans) {
            this._amigoService.AmigosProximos(id).subscribe((data) => {
                this.getAll();
            }, error => console.error(error))
        }
    }
    Add(form: any) {
        this._amigoService.Add(form).subscribe(
            result => {
                this.getAll();
            },
            error => console.error(error)
        );
    }
}

interface AmigoData {
    AmigoId: number;
    Nome: string;
    Latitude: number;
    Longitude: number;
    Distancia: number;
}