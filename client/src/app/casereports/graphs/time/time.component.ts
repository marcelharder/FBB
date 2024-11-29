import { Component, Input } from '@angular/core';
import { GraphModel } from '../../../_models/GraphModel';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-time',
  standalone: true,
  imports: [],
  templateUrl: './time.component.html',
  styleUrl: './time.component.css'
})
export class TimeComponent {
    
  @Input() gm: GraphModel = { DataXas: [], DataYas: [], DataFused:[],Caption: "" };
  
  constructor() { }

  ngOnInit(): void {
  this.RenderChart(this.gm);

  }

 RenderChart(test: GraphModel){
  const chart_01 = new Chart('barchart5',{
    type:'bar',
    data:{
      labels: test.DataXas,
      datasets:[
        {
        label: "Regular",
        data:test.DataYas,
        backgroundColor: "rgba(255,105,97,0.5)",
        
        },{
          label: "Fused",
          data:test.DataFused,
          backgroundColor: "rgba(128,239,128,0.5)",
          


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
