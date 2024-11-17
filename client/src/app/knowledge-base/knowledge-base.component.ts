import { Component } from '@angular/core';
import {TabsModule} from 'ngx-bootstrap/tabs';
import { GraphsComponent } from "../casereports/graphs/graphs.component";

@Component({
  selector: 'app-knowledge-base',
  standalone: true,
  imports: [TabsModule, GraphsComponent],
  templateUrl: './knowledge-base.component.html',
  styleUrl: './knowledge-base.component.css'
})
export class KnowledgeBaseComponent {

}
