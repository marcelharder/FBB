import { AfterContentInit, Component, inject, Input, OnInit } from '@angular/core';
import { User } from '../../_models/User';
import { UserdetailComponent } from "../userdetail/userdetail.component";
import { AccountService } from '../../_services/account.service';

@Component({
  selector: 'app-list-of-users',
  standalone: true,
  imports: [UserdetailComponent],
  templateUrl: './list-of-users.component.html',
  styleUrl: './list-of-users.component.css'
})
export class ListOfUsersComponent  {
  
  
@Input() listOfUsers: User[] = [];
private accountService = inject(AccountService);
selectedUser?: User= {} as User;


getSelectedUser(){return this.selectedUser};


getThisOne(id: number) {
  this.selectedUser = this.listOfUsers.find(x => x.Id == id);
  if(this.selectedUser){return this.selectedUser;}
  return null;
  

}

}
