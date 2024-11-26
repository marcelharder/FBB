import { Component, Input } from '@angular/core';
import { GraphModel } from '../../../_models/GraphModel';

@Component({
  selector: 'app-country',
  standalone: true,
  imports: [],
  templateUrl: './country.component.html',
  styleUrl: './country.component.css'
})
export class CountryComponent {
  @Input() gm: GraphModel = { DataXas: [], DataYas: [], DataFused:[],Caption: "" };
}
