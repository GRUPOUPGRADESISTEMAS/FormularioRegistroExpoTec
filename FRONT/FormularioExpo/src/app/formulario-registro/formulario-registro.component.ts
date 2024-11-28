import { Component, inject, OnInit, signal } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { AsyncPipe } from '@angular/common';
import { Empresas } from '../interfaces/Empresas';
import { filter, map, Observable, startWith } from 'rxjs';
import { __values } from 'tslib';
import { ApiService } from '../services/api.service';
import { error } from 'console';

@Component({
  selector: 'app-formulario-registro',
  standalone: true,
  imports: [FormsModule,MatFormFieldModule,MatInputModule,MatAutocompleteModule,ReactiveFormsModule,AsyncPipe],
  templateUrl: './formulario-registro.component.html',
  styleUrl: './formulario-registro.component.css'
})
export class FormularioRegistroComponent {
    public apiService = inject(ApiService)
    public empresas = new FormControl<string | Empresas> ("");
    public datosEmpresas: Empresas[] = [ ]
    public filtrado!:Observable<Empresas[]> ;
    
    
    ngOnInit(){
       this.filtrado = this.empresas.valueChanges.pipe(
        startWith(''),
        map(value => {
          const name = typeof value === 'string' ? value: value?.name;
          return name ? this._filter(name as string): this.datosEmpresas.slice()
        })
       )
       this.apiService.getAllEmpresas().subscribe(
        (data) => {
          this.datosEmpresas = data;
          console.log(data);
        },(error) => {
          console.error('Error al obtener Empresas' + error)
        }
        
       )

         
    }

    displayFn(user: Empresas): string {
       return user && user.name ? user.name: '';
    }

    private _filter(name: string): Empresas[]{
      const filterValue = name.toLowerCase();
      return this.datosEmpresas.filter(option => 
        option.name.toLowerCase().includes(filterValue))
    }
    

}
