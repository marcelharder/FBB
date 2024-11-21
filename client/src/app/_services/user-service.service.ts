import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;
  constructor() { }

  getAllUsers(){  return this.http.get<User[]>(this.baseUrl + 'User/getAllUsers')  }

  updateUser(user: User, id: number){return this.http.put<any>(this.baseUrl + 'User/' + id, user)  }

  deleteUser(id: number){return this.http.delete<string>(this.baseUrl + 'User/' + id, { responseType: 'text' as 'json' })}




  
}
