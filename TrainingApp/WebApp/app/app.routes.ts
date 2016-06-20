import { provideRouter } from '@angular/router';

import { MovimientosRoutes } from './movimientos/movimiento.routes';

export const routes = [
    //flatten the MovimientosRoutes into the routes array with the ES6 spread operator (...)
    ...MovimientosRoutes
];

export const APP_ROUTER_PROVIDERS = [
    provideRouter(routes)
];
