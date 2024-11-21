import { AfterContentInit, Component, inject, Input, OnInit } from '@angular/core';
import { User } from '../../_models/User';
import { UserdetailComponent } from "../userdetail/userdetail.component";
import { AccountService } from '../../_services/account.service';
import { UserServiceService } from '../../_services/user-service.service';

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
private userService = inject(UserServiceService);
selectedUser?: User= {} as User;
userDetails = 1;


showUserDetails(){if(this.userDetails != 0){return true} else {return false}}
getSelectedUser(){return this.selectedUser};

backFromUserDetails(evt: any){
  this.userDetails = 0;
  // renew the userlist
  this.listOfUsers = [];
  this.userService.getAllUsers().subscribe({
    next: (data)=>{this.listOfUsers = data}
  })

}


getThisOne(id: number) {
  this.userDetails = 1;
  this.selectedUser = this.listOfUsers.find(x => x.Id == id);
  if(this.selectedUser){return this.selectedUser;}
  return null;
  

}

}
