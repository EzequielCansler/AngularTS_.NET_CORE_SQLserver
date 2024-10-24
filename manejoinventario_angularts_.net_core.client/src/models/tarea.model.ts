import { Prioridad } from "./prioridad.model";

export class Tarea {
  Id?: number;
  Titulo: string;
  Descripcion: string;
  EstaCompleto: boolean;
  PrioID: number;
  Prioridad: Prioridad;

  constructor() {
    this.Titulo = '';
    this.Descripcion = '';
    this.EstaCompleto = false;
    this.PrioID = 1;
    this.Prioridad = new Prioridad();
  }
}
