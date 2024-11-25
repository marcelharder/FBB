import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { GraphModel } from '../_models/GraphModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GraphService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  //getVlad(userId: number,id: number) { return this.http.get<GraphModel>(this.baseUrl + 'Graph/vladGraphPerHospital/' + userId + '/' + id); }
  //getCM(userId: number,id: number) { return this.http.get<GraphModel>(this.baseUrl + 'Graph/cmGraphPerHospital/' + userId + '/' + id); }
  getAge():Observable<GraphModel> { return this.http.get<GraphModel>(this.baseUrl + 'graph/ageGraph'); }
  //getBand(userId: number,id: number) { return this.http.get<GraphModel>(this.baseUrl + 'Graph/euroGraphPerHospital/' + userId + '/' + id); }
  //getPM(userId: number,id: number) {return this.http.get<GraphModel>(this.baseUrl + 'Graph/proceduresPerMonthGraphPerHospital/' + userId + '/' + id); }
  //getPY(userId: number,id: number) {return this.http.get<GraphModel>(this.baseUrl + 'Graph/proceduresPerYearGraphPerHospital/' + userId + '/' + id); }

}
