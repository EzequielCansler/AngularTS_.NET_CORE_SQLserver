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
    const data = this.http.get<Tarea[]>(this.apiUrl);
    
    return data;
  }

  getTareaById(Id: number): Observable<Tarea> {
    
    return this.http.get<Tarea>(`${this.apiUrl}/${Id}`);
  }


  createOrUpdate(tarea: Tarea): Observable<any>
  {
    const body = JSON.stringify(tarea);
    return this.http.post(this.apiUrl, body, {
      headers: {
        'Content-Type': 'application/json'
      }
    });
  }
}
