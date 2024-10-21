import { Component, OnInit } from '@angular/core';
import { Tarea } from '../../../models/tarea.model';
import { TareaService } from '../../../../Service/TareaService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  tareas: Tarea[] = [];

  constructor(private tareaService: TareaService) { }

  ngOnInit(): void {
    this.loadTareas();
  }

  loadTareas(): void {
    this.tareaService.getAllTareas().subscribe(tareas => {
      this.tareas = tareas;
    })
  }
}
