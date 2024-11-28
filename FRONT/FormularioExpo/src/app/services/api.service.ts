import { HttpClient, HttpContext, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../interfaces/Environment';
import { catchError, Observable, throwError } from 'rxjs';
import { Empresas } from '../interfaces/Empresas';
import { error } from 'console';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  public empresas = signal<Empresas[]>([])

  constructor(private http: HttpClient) { }
  public readonly url = "https://expotec.grupoupgrade.com.pe/api/"


  getAllEmpresas(): Observable<Empresas[]> {
    let url = this.url + 'Cliente/ObtenerClientes';
    return this.http.get<Empresas[]>(url, {})
      .pipe(
        catchError((error: HttpErrorResponse) => {
          return throwError(() => error);
        })
      )

  }

  




}
