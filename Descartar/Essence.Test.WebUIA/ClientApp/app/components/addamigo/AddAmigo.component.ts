import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'addamigo',
    templateUrl: './addamigo.component.html'
})
export class AddAmigoComponent {

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        
    }
}
