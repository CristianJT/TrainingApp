import { Component, Input, OnInit } from '@angular/core';
import { NgForm }    from '@angular/common';

import { MODAL_DIRECTVES, BS_VIEW_PROVIDERS } from 'ng2-bootstrap';
import { ToastsManager } from 'ng2-toastr';

import { MovimientoService } from './movimiento.service';
import { Movimiento } from './movimiento';
import { Elemento, ELEMENTOS } from './elemento';

@Component({
    selector: 'movimiento-nuevo',
    templateUrl: 'app/movimientos/movimiento-nuevo.component.html',
    directives: [MODAL_DIRECTVES],
    viewProviders: [BS_VIEW_PROVIDERS]
})

export class MovimientoNuevoComponent {
    //class properties
    errorMessage: string;
    movimientos_nombre: any[];
    cargando: boolean;
    active: boolean;
    model: Movimiento;
    elementos: Elemento[];
    
    constructor(
        private movimientoService: MovimientoService,
        private toastr: ToastsManager
    ) { }

    @Input()
    movimientos: Movimiento[];

    ngOnInit() {
        this.model = new Movimiento();
        this.active = true;
        this.cargando = false;
        this.elementos = ELEMENTOS;
    }

    crearMovimiento() {
        this.movimientos_nombre = _.map(this.movimientos, 'nombre');
        if (!_.includes(this.movimientos_nombre, this.model.nombre)) {
            this.cargando = true;
            this.movimientoService.addMovimiento(this.model.nombre, this.model.tipo_elemento, this.model.descripcion)
                .subscribe(
                data => (
                    this.cargando = false,
                    this.toastr.success('Movimiento creado correctamente'),
                    this.movimientos.push(data),
                    this.model = new Movimiento(),
                    this.active = false,
                    setTimeout(() => this.active = true, 0)
                ),
                error => (
                    this.cargando = false,
                    this.toastr.error('No se ha podido crear el movimiento', 'Error!'),
                    this.errorMessage = <any>error
                ));
        } else
            this.toastr.warning('Ya existe un movimiento con ese nombre');
    }

}