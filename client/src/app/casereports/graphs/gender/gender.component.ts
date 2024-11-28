import { Component, Input } from '@angular/core';
import { GraphModel } from '../../../_models/GraphModel';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-gender',
  standalone: true,
  imports: [],
  templateUrl: './gender.component.html',
  styleUrl: './gender.component.css'
})
export class GenderComponent {
  @Input() gm: GraphModel = { DataXas: [], DataYas: [], DataFused:[],Caption: "" };
  
  constructor() { }

  ngOnInit(): void {
  this.RenderChart(this.gm);

  }

 RenderChart(test: GraphModel){
  const chart_01 = new Chart('barchart2',{
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
