import { bootstrap } from '@angular/platform-browser-dynamic';
import * as _ from 'lodash';

import { AppComponent } from './app.component';
import { APP_ROUTER_PROVIDERS } from './app.routes';

window._ = _;

bootstrap(AppComponent, [
    APP_ROUTER_PROVIDERS
]);