import { RouterConfig } from '@angular/router';

import { MovimientosComponent } from './movimientos.component';
import { MovimientoDetalleComponent } from './movimiento-detalle.component';

export const MovimientosRoutes: RouterConfig = [
    {
        path: '/movimientos',
        component: MovimientosComponent,
        index: true,
        children: [
            { path: '/:id', component: MovimientoDetalleComponent }
        ]
    }  
];