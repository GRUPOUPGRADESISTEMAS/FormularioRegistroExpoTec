import { AsyncPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ApiService } from '../services/api.service';
import { Empresas } from '../interfaces/Empresas';
import { map, Observable, startWith } from 'rxjs';
import { _RecycleViewRepeaterStrategy } from '@angular/cdk/collections';
import { error } from 'console';

@Component({
  selector: 'app-formulario-empresas',
  standalone: true,
  imports: [
    FormsModule,MatFormFieldModule,MatInputModule,MatAutocompleteModule,ReactiveFormsModule,AsyncPipe
  ],
  templateUrl: './formulario-empresas.component.html',
  styleUrl: './formulario-empresas.component.css'
})
export class FormularioEmpresasComponent {
    public apiService = inject(ApiService)
    public datos = new FormControl<string | Empresas>("");
    public datosEmpresa: Empresas[]  = [];
    public filtrado!:Observable<Empresas[]>;

    ngOnInit(){
      this.filtrado = this.datos.valueChanges.pipe(
        startWith(''),
        map(value => {
          const name = typeof value === 'string' ? value: value?.name
          return name ? this._filter(name as string): this.datosEmpresa.slice()
        })
      )
      this.apiService.getAllEmpresas().subscribe(
        (data) => {
          this.datosEmpresa = data;
        },(error) => {
          console.log('Error al obtener datos RUC' + error)
        }
      )  
    
    }

    displayFn(user: Empresas): string {
      return user && user.name ? user.name: '';
   }

   private _filter(dni: string): Empresas[]{
     const filterValue = dni.toLowerCase();
     return this.datosEmpresa.filter(option => 
       option.name.toLowerCase().includes(filterValue))
   
     }
}
