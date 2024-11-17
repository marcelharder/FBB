import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { CaseReportModel } from '../_models/CaseReportModel';

@Injectable({
  providedIn: 'root'
})
export class CasereportServiceService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;

  constructor() { }

  getAllCaseReports(){  return this.http.get<CaseReportModel[]>(this.baseUrl + 'CaseReport/getListOfCaseReports')  }
  createCaseReport(cr: CaseReportModel){ return this.http.put<CaseReportModel>(this.baseUrl + 'CaseReport', cr)  }
  updateCaseReport(cr: CaseReportModel){ return this.http.post<CaseReportModel>(this.baseUrl + 'CaseReport', cr)  }
  deleteCaseReport(id:number){ return this.http.delete<CaseReportModel>(this.baseUrl + 'CaseReport/' + id)  }
  getSpecificCaseReport(id:number){ return this.http.get<CaseReportModel>(this.baseUrl + 'CaseReport/' + id)  }
}
