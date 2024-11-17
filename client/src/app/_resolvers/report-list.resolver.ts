import { ResolveFn } from '@angular/router';
import { CaseReportModel } from '../_models/CaseReportModel';
import { CasereportServiceService } from '../_services/casereport-service.service';
import { inject } from '@angular/core';


export const reportListResolver: ResolveFn<CaseReportModel[] | null> = (route, state) => {
  const caseservice = inject(CasereportServiceService);

  return caseservice.getAllCaseReports();
};
