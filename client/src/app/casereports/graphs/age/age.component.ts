import { Component, Input, OnInit } from '@angular/core';
import { GraphModel } from '../../../_models/GraphModel';
import { BaseChartDirective } from 'ng2-charts';
import { ChartConfiguration, ChartOptions } from 'chart.js';

@Component({
  selector: 'app-age',
  standalone: true,
  imports: [BaseChartDirective],
  templateUrl: './age.component.html',
  styleUrls: ['./age.component.css']
})
export class AgeComponent implements OnInit {
  @Input() gm?: GraphModel;
  
  options = { hAxis: { title: 'Age groups' }, vAxis: { title: 'Age(years)' },};

  constructor() { }

  ngOnInit(): void {
   /*  var num: number = 0;
    var i: number;
    var help: Array<any> = [];
    for (i = num; i < this.gm.DataXas.length; i++) { help.push([this.gm.DataXas[i], this.gm.DataYas[i]]); }
    this.data = help;
   this.title = this.gm.Caption; */
  }

  public lineChartData: ChartConfiguration<'bar'>['data']={
    labels:this.gm?.DataXas,
    datasets:[
      {
        data:this.gm?.DataYas,
        label: 'Hallu',
        borderColor:'black',
        backgroundColor: 'rgba(255,0,0,0.3)'
      }
     /*  ,
      {
        data:this.gm.DataYas,
        label: 'Hallu-Nog',
        fill: true,
        tension: 0.5,
        borderColor:'black',
        backgroundColor: 'rgba(0,255,0,0.3)'
      } */
    ]
  }

  public lineChartOptions: ChartOptions<'bar'> = {
    responsive: false
  }

  public lineChartLegend = true;




}
