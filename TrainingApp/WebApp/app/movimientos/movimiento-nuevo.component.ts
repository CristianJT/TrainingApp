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

    @Input() grupos: any[];

    ngOnInit() {
        this.model = new Movimiento();
        this.active = true;
        this.cargando = false;
        this.elementos = ELEMENTOS;
    }

    asignarGrupo(movimiento) {
        let m = _.find(this.grupos, function (g) {
            return g.elemento_id == movimiento.tipo_elemento;
        });
        if (typeof m !== 'undefined')
            m.movimientos.push(movimiento);
        else {
            let movimientos_array = [movimiento];
            let nuevo_grupo = {
                elemento_id: movimiento.tipo_elemento,
                title: _.upperFirst(_.lowerCase(movimiento.tipo_elemento)),
                movimientos: movimientos_array
            }
            this.grupos.push(nuevo_grupo);
        }
        
    }

    crearMovimiento() {
        this.movimientos_nombre = _.flatten(_.map(this.grupos, function (g) { return _.map(g.movimientos, 'nombre') }));
        if (!_.includes(_.lowerCase(this.movimientos_nombre), _.lowerCase(this.model.nombre))) {
            this.cargando = true;
            this.movimientoService.addMovimiento(this.model.nombre, this.model.tipo_elemento, this.model.descripcion)
                .subscribe(
                data => (
                    this.cargando = false,
                    this.asignarGrupo(data),
                    this.toastr.success('Movimiento creado correctamente'),
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