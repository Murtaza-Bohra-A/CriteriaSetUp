import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { FloatLabelModule } from 'primeng/floatlabel';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-criteria',
  imports: [FormsModule, InputGroupModule, InputGroupAddonModule, InputTextModule, FloatLabelModule, ButtonModule, TableModule, CommonModule],
  templateUrl: './criteria.component.html',
  styleUrl: './criteria.component.scss'
})
export class CriteriaComponent {
  Source: string = ""
  Criteria: string = ""
  srNo: number = 0;
  products: any[] = [];

  loadCriteriatable() {
   this.products = [
      {
        name: "Murtaza",
        code: 1234,
        category: "Demo",
        quantity: 1
      }, {
        name: "Murtaza",
        code: 1234,
        category: "Demo",
        quantity: 1
      }
    ]
  }
}
