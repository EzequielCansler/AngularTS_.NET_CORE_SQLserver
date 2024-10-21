export class Tarea {
  id?: number;
  titulo: string;
  descripcion: string;
  estaCompleto: boolean;
  prioID: number;
  Prioridad: { nombre: string } = { nombre: '' };

  constructor() {
    this.titulo = '';
    this.descripcion = '';
    this.estaCompleto = false; // Inicializa si es completada o no
    this.prioID = 1; // Inicializa la prioridad

  }
}
