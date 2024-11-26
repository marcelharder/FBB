import { Component, Input, OnInit } from '@angular/core';
import { GraphModel } from '../../_models/GraphModel';

@Component({
  selector: 'app-outcomes',
  standalone: true,
  imports: [],
  templateUrl: './outcomes.component.html',
  styleUrl: './outcomes.component.css'
})
export class OutcomesComponent implements OnInit{
  
  @Input() gm: GraphModel = { DataXas: [], DataYas: [], Caption: "" };

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
}
