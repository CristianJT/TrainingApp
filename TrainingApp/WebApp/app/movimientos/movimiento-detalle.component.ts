import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { MovimientoService } from './movimiento.service';
import { Movimiento } from './movimiento';

@Component({
    selector: 'movimiento-detalle',
    templateUrl: 'app/movimientos/movimiento-detalle.component.html'
})

export class MovimientoDetalleComponent implements OnInit, OnDestroy {
    private sub: any;
    movimiento: Movimiento;
    errorMessage: string;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private service: MovimientoService
    ) { }

    ngOnInit() {
        //Detect when the route parameters change from within the same instance
        this.sub = this.route.params.subscribe(params => {
            let id = +params['id']; // (+) converts string 'id' to a number
            this.service.getMovimiento(id)
                .subscribe(
                data => this.movimiento = data,
                error => this.errorMessage = <any>error);
        });
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}