import { Component, inject } from '@angular/core';
import { AgeComponent } from './age/age.component';
import { GenderComponent } from './gender/gender.component';
import { TimeComponent } from './time/time.component';
import { CountryComponent } from './country/country.component';
import { GraphService } from '../../_services/graph.service';
import { GraphModel } from '../../_models/GraphModel';
import { take } from 'rxjs';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-graphs',
  standalone: true,
  imports: [AgeComponent, GenderComponent, TimeComponent, CountryComponent, NgIf],
  templateUrl: './graphs.component.html',
  styleUrl: './graphs.component.css'
})
export class GraphsComponent {
  showGraphNo = 1;
  private graph = inject(GraphService);
  gm: GraphModel = { DataXas: [], DataYas: [], Caption: "" };



  getAG() { this.graph.getAge().pipe(take(1)).subscribe({next: (data)=>{debugger;this.gm = data; this.showGraphNo = 1;}});return this.gm;}
  getCountry() { this.graph.getAge().pipe(take(1)).subscribe({next: (data)=>{this.gm = data; this.showGraphNo = 2;}});return this.gm;}
  getGender() { this.graph.getAge().pipe(take(1)).subscribe({next: (data)=>{this.gm = data; this.showGraphNo = 3;}});return this.gm;}
  getTime() { this.graph.getAge().pipe(take(1)).subscribe({next: (data)=>{this.gm = data; this.showGraphNo = 4;}});return this.gm;}
   



}
