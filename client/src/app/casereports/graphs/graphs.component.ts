import { Component, inject, OnInit } from '@angular/core';
import { AgeComponent } from './age/age.component';
import { GenderComponent } from './gender/gender.component';
import { TimeComponent } from './time/time.component';
import { CountryComponent } from './country/country.component';
import { GraphService } from '../../_services/graph.service';
import { GraphModel } from '../../_models/GraphModel';
import { take } from 'rxjs';
import { NgIf } from '@angular/common';
import { OutcomesComponent } from './outcomes/outcomes.component';

@Component({
  selector: 'app-graphs',
  standalone: true,
  imports: [AgeComponent, GenderComponent, TimeComponent, CountryComponent, NgIf, OutcomesComponent],
  templateUrl: './graphs.component.html',
  styleUrl: './graphs.component.css'
})
export class GraphsComponent implements OnInit{
  
  showGraphNo = 0;
  private graph = inject(GraphService);
  gm: GraphModel = { DataXas: [], DataYas: [],DataFused: [], Caption: "" };
  genderModel: GraphModel = { DataXas: [], DataYas: [],DataFused: [], Caption: "" };
  outcomesModel: GraphModel = { DataXas: [], DataYas: [],DataFused: [], Caption: "" };
  countriesModel: GraphModel = { DataXas: [], DataYas: [],DataFused: [], Caption: "" };

  ngOnInit(): void {
    // get age data
    this.graph.getAge().subscribe({ next: (data)=>{
      this.gm = data;
      this.showGraphNo = 1;
    } });
    // get gender data
    this.genderModel.Caption = "Gender";
    this.genderModel.DataFused = [4,10];
    this.genderModel.DataYas = [5,6];
    this.genderModel.DataXas = ["male","female"];
    
    // get outcomes data
    this.outcomesModel.Caption = "Outcomes";
    this.outcomesModel.DataFused = [0,1,2,1,0];
    this.outcomesModel.DataYas = [2,4,3,5,3];
    this.outcomesModel.DataXas = ["0","1","2","3","4","5"];

     // get countries
     this.countriesModel.Caption = "Contributions by country";
     this.countriesModel.DataFused = [10,1,2,1,0,5];
     this.countriesModel.DataYas = [2,4,3,5,3,5];
     this.countriesModel.DataXas = ["NL","BE","DE","FR","SA","UK"];

  }

  showAge(){if(this.showGraphNo == 1){return true;} else {return false;}}
  showCountry(){if(this.showGraphNo == 2){return true;} else {return false;}}
  showGender(){if(this.showGraphNo == 3){return true;} else {return false;}}
  showTime(){if(this.showGraphNo == 4){return true;} else {return false;}}
  showOutcomes(){if(this.showGraphNo == 5){return true;} else {return false;}}
 




 /*  getAG() { this.graph.getAge().pipe(take(1)).subscribe({next: (data)=>{debugger;this.gm = data; this.showGraphNo = 1;}});return this.gm;}
  getCountry() { this.graph.getAge().pipe(take(1)).subscribe({next: (data)=>{this.gm = data; this.showGraphNo = 2;}});return this.gm;}
  getGender() { this.graph.getAge().pipe(take(1)).subscribe({next: (data)=>{this.gm = data; this.showGraphNo = 3;}});return this.gm;}
  getTime() { this.graph.getAge().pipe(take(1)).subscribe({next: (data)=>{this.gm = data; this.showGraphNo = 4;}});return this.gm;}
  */  



}
