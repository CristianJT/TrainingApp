import { Component, OnInit } from '@angular/core';

import { MovimientoService } from './movimiento.service';
import { Movimiento } from './movimiento';
import { MovimientoNuevoComponent} from './movimiento-nuevo.component';

@Component({
    selector: 'movimientos',
    templateUrl: 'app/movimientos/movimientos.component.html',
    directives: [MovimientoNuevoComponent]
})

export class MovimientosComponent implements OnInit {
    movimientos: Movimiento[];
    errorMessage: string;

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