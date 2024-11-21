import { AfterContentInit, Component, inject, Input, OnInit } from '@angular/core';
import { User } from '../../_models/User';
import { UserServiceService } from '../../_services/user-service.service';
import { GeneralService } from '../../_services/general.service';
import { FormsModule} from '@angular/forms';

@Component({
  selector: 'app-userdetail',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './userdetail.component.html',
  styleUrl: './userdetail.component.css'
})
export class UserdetailComponent implements OnInit {
  @Input() cr?: User = {} as User;
  listOfUsers: User[] = [];
  private userService = inject(UserServiceService);
  EditBlok = 0;
  
  

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe({
      next: (data) => {
        this.listOfUsers = data;
        this.cr = this.listOfUsers[0];
       },
    });
}

showEditBlok(){if(this.EditBlok === 1){return true} else {return false}}


EditUser(){
this.EditBlok = 1;
}

DeleteUser(){
  // remove the current user

  // and renew the page
}

CancelUpdate(){this.EditBlok = 0;}

Update(){
  var help = this.cr?.Id;
  if(help != undefined && this.cr != undefined){
  this.userService.updateUser(this.cr, help).subscribe({
    next: (data)=>{
      this.EditBlok = 0;
    }
  })}
}




}
