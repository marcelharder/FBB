import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';
import { User } from '../_models/User';
import { map } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  http = inject(HttpClient);
  baseUrl = environment.apiUrl;
  
  currentUser = signal<User | null>(null);
  rollen = signal<string[]>([]);
  currentUserId = signal<number>(0);
 
  login(model: any){
  
    return this.http.post<User>(this.baseUrl + 'Account/login', model).pipe(
      map(user => {
     
        if(user){localStorage.setItem('user', JSON.stringify(user));}
        
        user.roles = [];
        const roles = this.getDecodedToken(user.Token).role; // get the roles from the token
        var help: string[] = [];
        help.push(roles);
        this.rollen.set(help);
        Array.isArray(roles) ? user.roles = roles : user.roles.push(roles); 
       
        this.currentUser.set(user);
        this.currentUserId.set(user.Id);

      })
    );
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUser.set(null);
    this.rollen.set([]);
  }
  getDecodedToken(token: string) { return JSON.parse(atob(token.split('.')[1])); }

  
}