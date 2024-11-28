import { Routes } from '@angular/router';
import { FormularioRegistroComponent } from './formulario-registro/formulario-registro.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FormularioEmpresasComponent } from './formulario-empresas/formulario-empresas.component';
import { FormularioInvitadosComponent } from './formulario-invitados/formulario-invitados.component';

export const routes: Routes = [
    {path: '', component:FormularioRegistroComponent},
    {path: 'formulario-registro', component:FormularioRegistroComponent},
    {path: 'navbar', component:NavbarComponent},
    {path: 'formulario-empresas', component: FormularioEmpresasComponent},
    {path: 'formulario-invitados', component: FormularioInvitadosComponent}

];
