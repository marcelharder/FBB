import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CaseReportModel } from '../../_models/CaseReportModel';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-report-detail',
  standalone: true,
  imports: [DatePipe],
  templateUrl: './report-detail.component.html',
  styleUrl: './report-detail.component.css'
})
export class ReportDetailComponent implements OnInit{


 
@Input() cr?: CaseReportModel = {} as CaseReportModel;

ngOnInit(): void {
  // get the first one first
}

GetAge(){return this.getAgeFromBDate(this.cr?.DateOfBirth)}


getAgeFromBDate(birthdate: Date): number {
  const today = new Date();
  const birthDate = new Date(birthdate);
  
  let age = today.getFullYear() - birthDate.getFullYear();
  
  if (today.getMonth() < birthDate.getMonth() || 
      (today.getMonth() === birthDate.getMonth() && today.getDate() < birthDate.getDate())) {
      age--;
  }
  
  return age;
}





}
