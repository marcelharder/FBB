import {Directive, inject, Input, OnInit, TemplateRef, ViewContainerRef} from '@angular/core';
import { AccountService } from '../_services/account.service';

@Directive(
  {
  selector: '[appHasRole]',
  standalone: true
}
)

export class HasRoleDirective implements OnInit{
@Input() appHasRole: string[] = [];
private accountService = inject(AccountService);
private viewContainerRef = inject(ViewContainerRef);
private templateRef = inject(TemplateRef);
    
  
  ngOnInit(): void {
    if(this.accountService.rollen()?.some((r: string) => this.appHasRole.includes(r))){
      debugger;
      this.viewContainerRef.createEmbeddedView(this.templateRef)
    } else {
      debugger;
      this.viewContainerRef.clear();
    }
  }

}