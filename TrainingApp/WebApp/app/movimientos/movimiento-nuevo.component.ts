import { Component } from '@angular/core';
import { NgForm }    from '@angular/common';

import { MODAL_DIRECTVES, BS_VIEW_PROVIDERS } from 'ng2-bootstrap';

import { MovimientoService } from './movimiento.service';
import { Movimiento } from './movimiento';

@Component({
    selector: 'movimiento-nuevo',
    templateUrl: 'app/movimientos/movimiento-nuevo.component.html',
    directives: [MODAL_DIRECTVES],
    viewProviders: [BS_VIEW_PROVIDERS]
})

export class MovimientoNuevoComponent {
    elementos = ['barra', 'barra_dominadas', 'ketllebell', 'pelota', 'soga', 'libre', 'anillas', 'cajon'];
    model = new Movimiento();
    active = true;
    errorMessage: string;

    constructor(
        private movimientoService: MovimientoService
    ) { }

    crearMovimiento() {
        this.active = false;
        setTimeout(() => this.active = true, 0);

        this.movimientoService.addMovimiento(this.model.nombre, this.model.tipo_elemento, this.model.descripcion)
            .subscribe(
            data => (console.log(data), this.model = new Movimiento()),
            error => this.errorMessage = <any>error);

    }
}