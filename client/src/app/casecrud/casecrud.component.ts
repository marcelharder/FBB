import { Component, inject, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms';
import { TextInputComponent } from "../_forms/text-input/text-input.component";
import { JsonPipe, NgFor } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { DatePickerComponent } from "../_forms/date-picker/date-picker.component";
import { dropItem } from '../_models/dropItem';
import { CasereportServiceService } from '../_services/casereport-service.service';
import { Router } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { GeneralService } from '../_services/general.service';


@Component({
  selector: 'app-casecrud',
  standalone: true,
  imports: [ReactiveFormsModule, TextInputComponent, JsonPipe, BsDropdownModule, DatePickerComponent,NgFor],
  templateUrl: './casecrud.component.html',
  styleUrl: './casecrud.component.css',
})
export class CasecrudComponent implements OnInit {
  registerCaseForm: FormGroup = new FormGroup({});
  private fb = inject(FormBuilder);
  private router = inject(Router);
  private caseReportService = inject(CasereportServiceService);
  private general = inject(GeneralService);
  private accountService = inject(AccountService);
  countries:dropItem[] = [];
 /*  countries: dropItem[] = [
    {value: 31, description: "Nederland"},
    {value: 33, description: "France"},
    {value: 32, description: "Belgium"},
    {value: 49, description: "Deutschland"},
    {value: 966, description: "Kingdom of Saudi Arabia"},
    {value: 1, description: "United States"}
  ]; */
  Outcomes_array: dropItem[] = [
    {Value: 0, Description: "Outcomes"},
    {Value: 1, Description: "No adverse outcome, with conservative therapy"},
    {Value: 2, Description: "Minor oesophageal injuries"},
    {Value: 3, Description: "Major injuries in mediastinum requiring surgical intervention"},
    {Value: 4, Description: "Major injuries in mediastinum requiring surgical intervention, permanent damage"},
    {Value: 5, Description: "Major injuries in mediastinum requiring surgical intervention, resulting in death"}
  ];

  ngOnInit(): void {
    this.initializeForm();
    this.general.getCountries().subscribe({
      next: (data)=>{this.countries = data}
    });

  }

  initializeForm() {
    this.registerCaseForm = this.fb.group({
      Lesion: ['', Validators.required],
      Gender: ['male'],
      BatteryType: ['regular'],
      Country: ['31', Validators.required],
      DateOfBirth: ['', Validators.required],
      Outcomes: ['0', Validators.required],
      ReferrerId:['0']
    });
  }

 /*  matchValues(matchTo: string):ValidatorFn{
    return (control: AbstractControl)=>{
      return control.value === control.parent?.get(matchTo)?.value ? null : {isMatching: true}
    }
  } */
  matchValues(matchTo: string):ValidatorFn{
    return (control: AbstractControl)=>{
      return control.value === matchTo ? null : {isMatching: true}
    }
  }

  sendUp() {
    const dob = this.getDateOnly(this.registerCaseForm.get('DateOfBirth')?.value);
    this.registerCaseForm.patchValue({DateOfBirth: dob});

    // attach the current referrer
    const ref = this.accountService.currentUserId();
    this.registerCaseForm.patchValue({ReferrerId: ref});

    this.caseReportService.createCaseReport(this.registerCaseForm.value).subscribe({
      next: _=> this.router.navigateByUrl('/'),
      error: error => {}
    })  
  }

  private getDateOnly(dob: string | undefined){
    if (!dob) return 
    return new Date(dob).toISOString().slice(0,10);
  }
}
