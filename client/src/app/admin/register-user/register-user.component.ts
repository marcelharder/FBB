import { Component, inject, OnInit } from '@angular/core';
import { TextInputComponent } from '../../_forms/text-input/text-input.component';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { GeneralService } from '../../_services/general.service';
import { dropItem } from '../../_models/dropItem';
import { JsonPipe, NgFor } from '@angular/common';
import { AccountService } from '../../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register-user',
  standalone: true,
  imports: [JsonPipe,NgFor, TextInputComponent, ReactiveFormsModule],
  templateUrl: './register-user.component.html',
  styleUrl: './register-user.component.css',
})
export class RegisterUserComponent implements OnInit {
  registerUserForm: FormGroup = new FormGroup({});
  private acc = inject(AccountService);
  private general = inject(GeneralService);
  private toast = inject(ToastrService);
  private fb = inject(FormBuilder);
  private router = inject(Router);
  countries: dropItem[] = [];

  ngOnInit(): void {
    this.initializeForm();
    this.general.getCountries().subscribe({
      next: (data) => {
        this.countries = data;
      },
    });
  }

  initializeForm() {
    this.registerUserForm = this.fb.group({
      UserName: [''],
      Email: ['', [Validators.required, Validators.email]],
      Mobile: ['', Validators.required],
      KnownAs: ['', Validators.required],
      password: ['', [
        Validators.required, 
        Validators.minLength(8),
        Validators.maxLength(30), 
        Validators.pattern(/^(?=\D*\d)(?=[^a-z]*[a-z])(?=.*[$@$!%*?&])(?=[^A-Z]*[A-Z]).{8,30}$/)
      ]],
      confirmPassword: ['', [Validators.required, this.matchValues('password')]],
      Gender: ['male'],
      Country: ['31', Validators.required],
    });
    this.registerUserForm.controls['password'].valueChanges.subscribe({
      next: ()=> this.registerUserForm.controls['confirmPassword'].updateValueAndValidity()

      
    })
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value
        ? null
        : { isMatching: true };
    };
  }

  sendUp() {
    const KN = this.registerUserForm.controls['Email'].value;
    this.registerUserForm.patchValue({UserName: KN});

    this.acc.register(this.registerUserForm.value).subscribe({
      next: _ => {
        this.toast.success("User added");
        this.router.navigateByUrl('/dashboard');
      },
      error: error => {console.log(error.error)}
    })

    
    
  }
}
