import { Component, inject, OnInit } from '@angular/core';
import { TextInputComponent } from "../../_forms/text-input/text-input.component";
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { GeneralService } from '../../_services/general.service';
import { dropItem } from '../../_models/dropItem';

@Component({
  selector: 'app-register-user',
  standalone: true,
  imports: [TextInputComponent, ReactiveFormsModule],
  templateUrl: './register-user.component.html',
  styleUrl: './register-user.component.css'
})
export class RegisterUserComponent implements OnInit {
  registerUserForm: FormGroup = new FormGroup({});
  private general = inject(GeneralService);
  private fb = inject(FormBuilder);
  private router = inject(Router);
  countries:dropItem[] = [];

  ngOnInit(): void {
    this.initializeForm();
    this.general.getCountries().subscribe({
      next: (data)=>{this.countries = data}
    });
  }

  initializeForm() {
    this.registerUserForm = this.fb.group({
      UserName: ['', Validators.required],
      Email: ['', Validators.required],
      Mobile: ['', Validators.required],
      KnownAs: ['', Validators.required],
      PaidTill: ['', Validators.required],
      Password: ['', Validators.required],
      ConfirmPassword: ['', Validators.required],
      Gender: ['male'],
      Country: ['31', Validators.required],
       });
  }
  






  sendUp(){}

}


