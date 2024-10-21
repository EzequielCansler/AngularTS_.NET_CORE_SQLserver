import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Prioridad } from '../src/models/prioridad.model'; 

@Injectable({
  providedIn: 'root'
})
export class PrioridadService {
  private prioridadUrl = "https://localhost:7006/api/prioridad";


  constructor(private http: HttpClient) { }

  getAll(): Observable<Prioridad[]> {
    return this.http.get<Prioridad[]>(this.prioridadUrl);
  }

}
