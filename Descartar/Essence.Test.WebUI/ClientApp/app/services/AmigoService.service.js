var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
var AmigoService = /** @class */ (function () {
    function AmigoService(_http, baseUrl) {
        this._http = _http;
        this.myAppUrl = "";
        this.myAppUrl = 'http://localhost:61792/'; //baseUrl;
    }
    AmigoService.prototype.AmigosProximos = function (id) {
        return this._http.get(this.myAppUrl + "api/Amigo/AmigosProximos/" + id)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    AmigoService.prototype.GetAll = function () {
        return this._http.get(this.myAppUrl + 'api/Amigo/GetAll')
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    AmigoService.prototype.Add = function (amigoModel) {
        return this._http.post(this.myAppUrl + 'api/Amigo/Add', amigoModel)
            .map(function (response) { return response.json(); })
            .catch(this.errorHandler);
    };
    AmigoService.prototype.errorHandler = function (error) {
        console.log(error);
        return Observable.throw(error);
    };
    AmigoService = __decorate([
        Injectable(),
        __param(1, Inject('BASE_URL')),
        __metadata("design:paramtypes", [Http, String])
    ], AmigoService);
    return AmigoService;
}());
export { AmigoService };
var AmigoModel = /** @class */ (function () {
    function AmigoModel() {
    }
    return AmigoModel;
}());
export default AmigoModel;
//# sourceMappingURL=amigo.service.js.map