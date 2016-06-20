import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {CORE_DIRECTIVES, FORM_DIRECTIVES, NgClass} from '@angular/common';

import { CHART_DIRECTIVES } from 'ng2-charts/ng2-charts';

import { MovimientoService } from './movimiento.service';
import { Movimiento } from './movimiento';

@Component({
    selector: 'movimiento-detalle',
    templateUrl: 'app/movimientos/movimiento-detalle.component.html',
    directives: [CHART_DIRECTIVES, NgClass, CORE_DIRECTIVES, FORM_DIRECTIVES]
})

export class MovimientoDetalleComponent implements OnInit, OnDestroy {
    private sub: any;
    movimiento: Movimiento;
    errorMessage: string;

    public lineChartType: string = 'line';
    public lineChartData: Array<number[]>;
    public lineChartLabels: any[];

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
                data => (
                    this.movimiento = data,
                    this.armarGraficoData(data)
                ),
                error => this.errorMessage = <any>error);
        });
    }

    armarGraficoData(movimiento) {
        let grafico_data = [];
        let grafico_labels = [];
        _.forIn(_.groupBy(movimiento.wods, 'wod_fecha'), function (value, key) {
            grafico_data.push(_.maxBy(value, 'peso').peso);
            grafico_labels.push(key)
        });
        this.lineChartData = grafico_data;
        this.lineChartLabels = grafico_labels;
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}