import { Component, Input } from '@angular/core';
import { GraphModel } from '../../../_models/GraphModel';

@Component({
  selector: 'app-time',
  standalone: true,
  imports: [],
  templateUrl: './time.component.html',
  styleUrl: './time.component.css'
})
export class TimeComponent {
  @Input() gm: GraphModel;
}
