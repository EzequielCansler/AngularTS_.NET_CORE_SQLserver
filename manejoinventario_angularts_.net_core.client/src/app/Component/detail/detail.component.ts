import { Component } from '@angular/core';
import { TareaService } from '../../../../Service/TareaService'
import { Tarea } from '../../../models/tarea.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrl: './detail.component.css'
})
export class DetailComponent {
  tarea: Tarea = new Tarea();


  constructor(private route:ActivatedRoute, private tareaService: TareaService) { }

  ngOnInit(): void {
    const Id = this.route.snapshot.paramMap.get('Id');
    if (Id) {
      this.loadTareaById(+Id);

    }
  }

  loadTareaById(Id: number): void {
    this.tareaService.getTareaById(Id).subscribe(tarea => {
      this.tarea = tarea;
    })
  }


}
