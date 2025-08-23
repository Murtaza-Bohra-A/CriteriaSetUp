import { Routes } from '@angular/router';
import { CriteriaComponent } from './Components/criteria/criteria.component';
import { AppComponent } from './app.component';
import { WellcomeComponent } from './Components/wellcome/wellcome.component';

export const routes: Routes = [
  { component: CriteriaComponent, path: 'CriteriaSetup' },
  { component: WellcomeComponent, path: '' }, // Default route }
];
