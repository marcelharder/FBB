import { Component, inject, Input, OnInit } from '@angular/core';
import { GraphModel } from '../../../_models/GraphModel';
import { Chart, registerables} from 'chart.js';
import { GraphService } from '../../../_services/graph.service';
Chart.register(...registerables)

@Component({
  selector: 'app-age',
  standalone: true,
  imports: [],
  templateUrl: './age.component.html',
  styleUrls: ['./age.component.css']
})
export class AgeComponent implements OnInit {
  @Input() gm: GraphModel = { DataXas: [], DataYas: [], Caption: "" };
  //private graph = inject(GraphService);
  //gm: GraphModel = { DataXas: [], DataYas: [], Caption: "" };
 
  constructor() { }

  ngOnInit(): void {
  //this.graph.getAge().subscribe({ next: (data)=>{this.gm = data} })
  this.RenderChart(this.gm);

  }

 RenderChart(test: GraphModel){
  const chart_01 = new Chart('barchart',{
    type:'bar',
    data:{
      labels: test.DataXas,
      datasets:[{
        label: test.Caption,
        data:test.DataYas
      }]
    },
    options: {
      scales: {
        y: {
          beginAtZero: true,
        }
      }
    }
  })
 }



}
