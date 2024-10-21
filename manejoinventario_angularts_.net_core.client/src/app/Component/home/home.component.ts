import { Component, OnInit } from '@angular/core';
import { Tarea } from '../../../models/tarea.model';
import { TareaService } from '../../../../Service/TareaService';
import { PrioridadService } from'../../../../Service/PrioridadService'
import { FormBuilder, FormGroup } from '@angular/forms';
import { Prioridad } from '../../../models/prioridad.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  tareas: Tarea[] = [];
  tarea: Tarea = new Tarea();
  editMode: boolean = false;
  prioridades: Prioridad[] = [];
  tareaForm: FormGroup;

  constructor(private tareaService: TareaService, private prioridadService: PrioridadService, private fb: FormBuilder) {
    this.tareaForm = this.fb.group({
      id: [null],
      titulo: [''],
      descripcion: [''],
      prioID:[''],
    });
  }

  ngOnInit(): void {
    this.loadTareas();
    this.loadPrioridades();
  }

  loadTareas(): void {
    this.tareaService.getAllTareas().subscribe(tareas => {
      this.tareas = tareas;
    })
  }

  loadPrioridades(): void {
    this.prioridadService.getAll().subscribe(prioridades => {
      this.prioridades = prioridades;
    });
  }

  createOrUpdate(): void
  {
    const tareaData = this.tareaForm.value;

    if (this.editMode) {
      // Si estamos en modo edición, utilizamos el ID existente
      tareaData.id = this.tarea.id; // Asegúrate de que el ID se añada a los datos de la tarea
    }

    this.tareaService.createOrUpdate(tareaData,null).subscribe(
      response => {
        console.log(response.message);
        this.loadTareas();
        this.resetForm();
      },
      error => {
        console.log(error.message);
      }
    );
  }





  resetForm(): void {
    this.tarea = new Tarea();
    this.editMode = false;
  }

}
