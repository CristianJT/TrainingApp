import { Component, ViewContainerRef } from '@angular/core';
import { HTTP_PROVIDERS } from '@angular/http';
import { ROUTER_DIRECTIVES } from '@angular/router';

import { ToastsManager } from 'ng2-toastr';

import './rxjs-operators';

//Decorator to associate metadata (how to create and use this component) with the component class
@Component({
    selector: 'my-app',       //represents the component. Create an instance of the component
    template: `
        <div class="container-fluid">
             <nav>
                <a [routerLink]="['/movimientos']">Movimientos</a>
            </nav>
            <router-outlet></router-outlet>
        </div>        
    `,
    directives: [
        ROUTER_DIRECTIVES,
    ],
    providers: [
        HTTP_PROVIDERS,
        ToastsManager
    ]
})

export class AppComponent {
    title = 'Trainning app';
    viewContainerRef: ViewContainerRef;

    public constructor(viewContainerRef: ViewContainerRef) {
        // You need this small hack in order to catch application root view container ref
        this.viewContainerRef = viewContainerRef;
    }
}