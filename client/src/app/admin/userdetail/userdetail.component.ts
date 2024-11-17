import { AfterContentInit, Component, inject, Input, OnInit } from '@angular/core';
import { User } from '../../_models/User';
import { UserServiceService } from '../../_services/user-service.service';
import { GeneralService } from '../../_services/general.service';

@Component({
  selector: 'app-userdetail',
  standalone: true,
  imports: [],
  templateUrl: './userdetail.component.html',
  styleUrl: './userdetail.component.css'
})
export class UserdetailComponent implements OnInit {
  @Input() cr?: User = {} as User;
  listOfUsers: User[] = [];
  private userService = inject(UserServiceService);
  
  

  ngOnInit(): void {

    this.userService.getAllUsers().subscribe({
      next: (data) => {
        this.listOfUsers = data;
        this.cr = this.listOfUsers[0];
       
      },
    });
  
 




}






}
