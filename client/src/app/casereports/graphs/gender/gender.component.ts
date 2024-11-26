import { Component, Input } from '@angular/core';
import { GraphModel } from '../../../_models/GraphModel';

@Component({
  selector: 'app-gender',
  standalone: true,
  imports: [],
  templateUrl: './gender.component.html',
  styleUrl: './gender.component.css'
})
export class GenderComponent {
  @Input() gm: GraphModel = { DataXas: [], DataYas: [], DataFused:[],Caption: "" };
}
