import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { FloatLabelModule } from 'primeng/floatlabel';
import { ButtonModule } from 'primeng/button';
@Component({
  selector: 'app-criteria',
  imports: [FormsModule, InputGroupModule, InputGroupAddonModule, InputTextModule, FloatLabelModule, ButtonModule],
  templateUrl: './criteria.component.html',
  styleUrl: './criteria.component.scss'
})
export class CriteriaComponent {
  value: string=""
}
