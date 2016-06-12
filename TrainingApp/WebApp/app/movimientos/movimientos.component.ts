import { Component, OnInit } from '@angular/core';

import { MovimientoService } from './movimiento.service';
import { Movimiento } from './movimiento';

@Component({
    selector: 'movimientos',
    template: `
        <h2>Movimientos</h2>
        <ul>
          <li *ngFor="let movimiento of movimientos">
            <span>{{movimiento.nombre}} - {{movimiento.tipo_elemento}}</span>
          </li>
        </ul>
    `
})

export class MovimientosComponent implements OnInit {
    movimientos: Movimiento[];
    errorMessage: string;
    mode = 'Observable';

    constructor(
        private movimientoService: MovimientoService
    ) { }

    getMovimientos() {
        this.movimientoService.getMovimientos()
            .subscribe(
            data => this.movimientos = data,
            error => this.errorMessage = <any>error);
    }

    ngOnInit() {
        this.getMovimientos();
    }
}