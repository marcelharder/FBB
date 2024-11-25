import {
  AfterContentInit,
  Component,
  EventEmitter,
  inject,
  Input,
  OnInit,
  Output,
} from '@angular/core';
import { User } from '../../_models/User';
import { UserServiceService } from '../../_services/user-service.service';
import { GeneralService } from '../../_services/general.service';
import { FormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { FotoUploaderComponent } from '../../foto-uploader/foto-uploader.component';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-userdetail',
  standalone: true,
  imports: [FormsModule,FotoUploaderComponent],
  templateUrl: './userdetail.component.html',
  styleUrl: './userdetail.component.css',
})
export class UserdetailComponent implements OnInit {
  @Input() cr?: User = {} as User;
  @Output() up = new EventEmitter<string>();

  listOfUsers: User[] = [];
  private userService = inject(UserServiceService);
  private toast = inject(ToastrService);
  EditBlok = 0;
  baseUrl = environment.apiUrl;

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe({
      next: (data) => {
        this.listOfUsers = data;
        this.cr = this.listOfUsers[0];
      },
    });
  }

  getTargetUrl(){return this.baseUrl + "User/addUserPhoto/" + this.cr.Id};

  showEditBlok() {
    if (this.EditBlok === 1) {
      return true;
    } else {
      return false;
    }
  }

  EditUser() {
    this.EditBlok = 1;
  }

  DeleteUser() {
    // remove the current user, if user is not demo of admin
    
    var help = this.cr?.Id;
    if (help != undefined) {
      if(help == 7){this.toast.error("Can't delete the demo user")}
      else{
      if(help == 8){this.toast.error("Can't delete the admin user")} else {
      this.userService.deleteUser(help).subscribe({
        next: (data) => {
          this.up.emit("close");
        },
      });
    }
  }
    }
  }

  CancelUpdate() { this.EditBlok = 0; }

  changePhoto(url: any){this.cr.PhotoUrl = url;}

  Update() {
    var help = this.cr?.Id;
    if (help != undefined && this.cr != undefined) {
      this.userService.updateUser(this.cr, help).subscribe({
        next: (data) => {
          this.EditBlok = 0;
        },
      });
    }
  }
  GetNotReady(){return this.toast.error("Not implemented yet ...")}
}
