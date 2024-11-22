import { Component } from '@angular/core';
import { AgeComponent } from './age/age.component';
import { GenderComponent } from './gender/gender.component';
import { TimeComponent } from './time/time.component';
import { CountryComponent } from './country/country.component';

@Component({
  selector: 'app-graphs',
  standalone: true,
  imports: [AgeComponent, GenderComponent, TimeComponent, CountryComponent],
  templateUrl: './graphs.component.html',
  styleUrl: './graphs.component.css'
})
export class GraphsComponent {
  graphToSelect = 1;





  selectGraph(id: number) {  this.graphToSelect = id;  }



}
