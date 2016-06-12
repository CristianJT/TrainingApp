import { Component } from '@angular/core';
import { HTTP_PROVIDERS } from '@angular/http';

import { MovimientoService } from './movimientos/movimiento.service';
import { MovimientosComponent } from './movimientos/movimientos.component';

import './rxjs-operators';

//Decorator to associate metadata (how to create and use this component) with the component class
@Component({
    selector: 'my-app',       //represents the component. Create an instance of the component
    template: `
        <div class="container-fluid">
            <h1>{{title}}</h1>
            <movimientos></movimientos>
        </div>        
    `,
    directives: [MovimientosComponent],
    providers: [
        HTTP_PROVIDERS,
        MovimientoService
    ]
})

export class AppComponent {
    title = 'Trainning app';
}