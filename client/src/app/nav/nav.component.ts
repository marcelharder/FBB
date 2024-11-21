import { Component, inject, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, RouterLink, RouterLinkActive,NgIf],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent implements OnInit{
  accountService = inject(AccountService);
  route = inject(Router);
   model:any = {};
  currentUserName?: any;
  selector: string[] = ['Admin'];
  
  ngOnInit(): void {
    // this.currentUserName = "Marcel Harder";
    this.currentUserName = null;
   
    
  }
  adminLoggedIn(){
    if(this.accountService.rollen().some(r => this.selector.includes(r))){return true;} else {return false;}}
  
  login(){
    this.accountService.login(this.model).subscribe({
      next: response => {
        this.currentUserName = this.accountService.currentUser()?.UserName;
      },
      error: error => { console.log(error); },
      complete: () => { }
    })  
  }

  logout(){
    this.route.navigateByUrl('/');
    this.accountService.logout()};

}

