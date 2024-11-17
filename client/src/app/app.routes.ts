import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListReportsComponent } from './admin/list-reports/list-reports.component';
import { KnowledgeBaseComponent } from './knowledge-base/knowledge-base.component';
import { AboutComponent } from './about/about.component';
import { CasecrudComponent } from './casecrud/casecrud.component';
import { ListOfUsersComponent } from './admin/list-of-users/list-of-users.component';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { reportListResolver } from './_resolvers/report-list.resolver';
import { RegisterUserComponent } from './admin/register-user/register-user.component';

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'knowledge', component: KnowledgeBaseComponent},
    {path: 'about', component:AboutComponent},
    {path: 'casecrud', component: CasecrudComponent},
    {path: 'listReports', component:ListReportsComponent},
    {path: 'listUsers', component: ListOfUsersComponent},
    {path: 'register', component: RegisterUserComponent},
    {path: 'dashboard', component: DashboardComponent,resolve:{list: reportListResolver}}
];
