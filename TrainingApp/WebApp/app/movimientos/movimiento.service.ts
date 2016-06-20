import { Injectable } from '@angular/core';
import { Headers, Http, Response, RequestOptions } from '@angular/http';

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

    getMovimiento(id): Observable<Movimiento> {
        return this.http.get(this.movimientoUrl + '/' + id)
            .map(this.extractData)
            .catch(this.handleError);
    }

    addMovimiento(nombre: string, tipo_elemento: string, descripcion: string): Observable<Movimiento> {
        let body = JSON.stringify({ nombre, tipo_elemento, descripcion });
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.movimientoUrl, body, options)
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