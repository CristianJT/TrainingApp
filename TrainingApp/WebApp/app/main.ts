import { bootstrap } from '@angular/platform-browser-dynamic';
import * as _ from 'lodash';

import { AppComponent } from './app.component';

window._ = _;

bootstrap(AppComponent);