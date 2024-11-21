import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CaseReportModel } from '../../_models/CaseReportModel';

@Component({
  selector: 'app-report-detail',
  standalone: true,
  imports: [],
  templateUrl: './report-detail.component.html',
  styleUrl: './report-detail.component.css'
})
export class ReportDetailComponent {
@Input() cr?: CaseReportModel = {} as CaseReportModel;







}
