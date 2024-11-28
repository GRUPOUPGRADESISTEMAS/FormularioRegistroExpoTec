import { Component, OnInit, signal } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { AsyncPipe } from '@angular/common';
import { empresas } from '../interfaces/Empresas';
import { Observable, startWith } from 'rxjs';
import { __values } from 'tslib';

@Component({
  selector: 'app-formulario-registro',
  standalone: true,
  imports: [FormsModule,MatFormFieldModule,MatInputModule,MatAutocompleteModule,ReactiveFormsModule,AsyncPipe],
  templateUrl: './formulario-registro.component.html',
  styleUrl: './formulario-registro.component.css'
})
export class FormularioRegistroComponent {
    public empresas = new FormControl<string | empresas> ("");
    public datosEmpresas: empresas[] = [{id_: "12",name:"Davalos", ruc: "021356584", address: "Manzanitos", region: "Arequipa"}]
    public filtrado!:Observable<empresas[]> ;
    
    
    ngOnInit(){
          
           
         
    }



}
