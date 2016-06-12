﻿import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';

import { Observable }     from 'rxjs/Observable';

import {Movimiento} from './movimiento';

@Injectable()
export class MovimientoService {
    private movimientoUrl = '/api/movimientos';

    constructor(private http: Http) { }

    getMovimientos(): Observable<Movimiento[]> {
        return this.http.get(this.movimientoUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body;
    }

    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}