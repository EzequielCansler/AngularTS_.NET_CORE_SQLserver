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
      Id: [null],
      Titulo: [''],
      Descripcion: [''],
      PrioID: [null],
    });
  }

  ngOnInit(): void {
    this.loadTareas();
    this.loadPrioridades();
  }

  loadTareas(): void {
    this.tareaService.getAllTareas().subscribe(tareas => {
      console.log(tareas);
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
      tareaData.Id = this.tarea.Id;
    }
    else {
      
      tareaData.EstaCompleto = false;
    }

    tareaData.PrioID = parseInt(tareaData.PrioID, 10);
    console.log(tareaData);
    this.tareaService.createOrUpdate(tareaData).subscribe(
      response => {
        console.log('Respuesta del servidor:', response);
        this.loadTareas();
        this.resetForm();
      },
      error => {
        console.log(error.message); // mensaje generico de error 400/405/500 etc
        console.log('Detalles del error:', error.error); // muy bueno para encontrar el error, devuelve el objeto con detalles de validacion
      }
    );
  }

  editTarea(tarea: Tarea): void {
    this.tarea = tarea; // Cargar la tarea a editar
    this.editMode = true; // Cambiar a modo edición

    // Llenar el formulario con los valores de la tarea
    this.tareaForm.patchValue({
      id: tarea.Id,
      titulo: tarea.Titulo,
      descripcion: tarea.Descripcion,
      prioID: tarea.PrioID
    });
  }

  resetForm(): void {
    {
      this.tareaForm.reset({
        Id: null,
        Titulo: '',
        Descripcion: '',
        PrioID: null
      });
      this.editMode = false;
    }


  }
}
