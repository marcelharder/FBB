import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GeneralService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;

  constructor() { }

  getCountryName(id: string | undefined){  return this.http.get<string>(this.baseUrl + 'General/getCountryNameFromCode/' + id)  }
}