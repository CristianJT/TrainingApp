import { Component, OnInit } from '@angular/core';

import { ACCORDION_DIRECTIVES } from 'ng2-bootstrap';

import { MovimientoService } from './movimiento.service';
import { Movimiento } from './movimiento';
import { MovimientoNuevoComponent} from './movimiento-nuevo.component';

@Component({
    selector: 'movimientos',
    templateUrl: 'app/movimientos/movimientos.component.html',
    directives: [MovimientoNuevoComponent, ACCORDION_DIRECTIVES]
})

export class MovimientosComponent implements OnInit {
    errorMessage: string;
    groups: any[];

    constructor(
        private movimientoService: MovimientoService
    ) { }

    getMovimientos() {
        this.movimientoService.getMovimientos()
            .subscribe(
            data => this.groups = this.asignarGrupos(data),
            error => this.errorMessage = <any>error);
    }

    asignarGrupos(data) {
        let array = [];
        _.forIn(_.groupBy(data, 'tipo_elemento'), function (value, key) {
            let object = {
                elemento_id: key,
                title: _.upperFirst(_.lowerCase(key)),
                movimientos: value
            }
            array.push(object);
        }) 
        return array;
    }

    ngOnInit() {
        this.getMovimientos();
    }

}