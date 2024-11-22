import { Component, EventEmitter, inject, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { FileUploader, FileUploadModule } from 'ng2-file-upload';
import { AccountService } from '../_services/account.service';
import { environment } from '../../environments/environment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-foto-uploader',
  standalone: true,
  imports: [FileUploadModule],
  templateUrl: './foto-uploader.component.html',
  styleUrl: './foto-uploader.component.css'
})
export class FotoUploaderComponent implements OnInit,OnDestroy{
@Input() targetUrl: string;
@Output() getMemberPhotoChange = new EventEmitter<string>();
private acc = inject(AccountService);
private toast = inject(ToastrService);
uploader?: FileUploader;
hasBaseDropzoneOver: false;
baseUrl = environment.apiUrl;

ngOnInit(): void {
  this.initializeUploader();
}
ngOnDestroy(): void {
    this.targetUrl = "";
}


initializeUploader(){
  this.uploader = new FileUploader({
    url: this.targetUrl,
    authToken: 'Bearer ' + this.acc.currentUser()?.Token,
    isHTML5: true,
    allowedFileType: ['image'],
    removeAfterUpload: true,
    autoUpload: false,
    maxFileSize: 10 * 1024 * 1024

  });
  this.uploader.onAfterAddingFile = (file) => {
    file.withCredentials = false;
    this.toast.success("Uploaded ...");
    
  };
  this.uploader.onSuccessItem = (item,response,status,headers)=>{
    const photo = JSON.parse(response);
    this.getMemberPhotoChange.emit(photo);

  }
}

}
