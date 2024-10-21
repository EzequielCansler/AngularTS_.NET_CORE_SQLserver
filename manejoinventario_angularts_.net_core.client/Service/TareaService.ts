import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tarea } from '../src/models/tarea.model';

@Injectable({
  providedIn: 'root'
})

export class TareaService {
  private apiUrl = "https://localhost:7006/api/tarea";
  constructor(private http: HttpClient) { }

  getAllTareas(): Observable<Tarea[]> {
    return this.http.get<Tarea[]>(this.apiUrl);
  }

  getTareasById(id: number): Observable<Tarea> {
    return this.http.get<Tarea>(`${this.apiUrl}/${id}`);
  }
}
