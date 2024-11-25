import { Component, Input, OnInit } from '@angular/core';
import { CaseReportModel } from '../../_models/CaseReportModel';
import { DatePipe } from '@angular/common';
import { ReportDetailComponent } from "../report-detail/report-detail.component";

@Component({
  selector: 'app-list-reports',
  standalone: true,
  imports: [DatePipe, ReportDetailComponent],
  templateUrl: './list-reports.component.html',
  styleUrl: './list-reports.component.css',

})
export class ListReportsComponent implements OnInit {
  @Input() listOfCases: CaseReportModel[] = [];
  selectedReport?:CaseReportModel = {} as CaseReportModel;
  
  ngOnInit(): void {
    this.selectedReport = this.listOfCases[0];
  }

  getSelectedReport(){return this.selectedReport};

  
 
  getThisOne(id: number) {
   
    this.selectedReport = this.listOfCases.find(x => x.CaseReportNo == id);
    if(this.selectedReport != null){return this.selectedReport;}
    return null;
  }

  
  
}
