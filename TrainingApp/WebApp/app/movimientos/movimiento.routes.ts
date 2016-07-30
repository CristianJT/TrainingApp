import { RouterConfig } from '@angular/router';

import { MovimientosComponent } from './movimientos.component';
import { MovimientoDetalleComponent } from './movimiento-detalle.component';

export const MovimientosRoutes: RouterConfig = [
    {
        path: '',
        redirectTo: '/movimientos',
        pathMatch: 'full'
    },
    {
        path: 'movimientos',
        component: MovimientosComponent,
        children: [
            { path: ':id', component: MovimientoDetalleComponent },
            { path: '', component: MovimientosComponent }
        ]
    }  
];