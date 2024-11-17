import { Component, inject, OnInit } from '@angular/core';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ListOfUsersComponent } from '../list-of-users/list-of-users.component';
import { ListReportsComponent } from '../list-reports/list-reports.component';
import { environment } from '../../../environments/environment';
import { CaseReportModel } from '../../_models/CaseReportModel';
import { ActivatedRoute, Router } from '@angular/router';
import { CasereportServiceService } from '../../_services/casereport-service.service';
import { UserServiceService } from '../../_services/user-service.service';
import { User } from '../../_models/User';
import { AccountService } from '../../_services/account.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [TabsModule, ListOfUsersComponent, ListReportsComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})
export class DashboardComponent implements OnInit {
  baseUrl = environment.apiUrl;
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private accountService = inject(AccountService);
  private caseService = inject(CasereportServiceService);
  private userService = inject(UserServiceService);
  listOfCases: CaseReportModel[] = [];
  listOfUsers: User[] = [];

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe({
      next: (data) => {
        this.listOfUsers = data;
        this.accountService.currentUserId.set(this.listOfUsers[0].Id);
      },
    }); 
    this.route.data.subscribe({
     next: (data) => {
       this.listOfCases = data['list'];
     },
     error: (error)=>{console.log(error)}
   });  
  }

  

  addRef(){
    // go to the register page
    this.router.navigateByUrl('/register');
  }

}
