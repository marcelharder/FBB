import { Component } from '@angular/core';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { GraphsComponent } from '../casereports/graphs/graphs.component';

@Component({
  selector: 'app-knowledge-base',
  standalone: true,
  imports: [TabsModule, GraphsComponent],
  templateUrl: './knowledge-base.component.html',
  styleUrl: './knowledge-base.component.css',
})
export class KnowledgeBaseComponent {
  gotoExternalDomain() {
    (window as any).open('https://www.poison.org/battery/guideline', '_blank');
  }
  goIngestionStatistics() {
    (window as any).open('https://www.poison.org/battery/stats', '_blank');
  }

  literature(x: number) {
    switch (x) {
      case 1:
        (window as any).open(
          'https://publications.aap.org/pediatrics/article/150/3/e2022057477/189222/Vascular-Complications-in-Children-Following?autologincheck=redirected',
          '_blank'
        );
        break;
      case 2:
        (window as any).open(
          'https://www.tandfonline.com/doi/full/10.1080/15563650.2023.2294622',
          '_blank'
        );
        break;
    }
  }
}
