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
import { DropdownModule } from 'primeng/dropdown';

@Component({
  selector: 'app-criteria',
  imports: [FormsModule, InputGroupModule, InputGroupAddonModule, InputTextModule, FloatLabelModule, ButtonModule, TableModule, CommonModule, DropdownModule],
  templateUrl: './criteria.component.html',
  styleUrl: './criteria.component.scss'
})
export class CriteriaComponent {
  Source: any;   // bound value

  sources = [
    { label: 'Database', value: 'DB' },
    { label: 'API', value: 'API' },
    { label: 'File Upload', value: 'FILE' }
  ];


  Criteria: string = ""
  srNo: number = 0;
  criteria: any[] = [];

  loadCriteriatable() {
    this.criteria = [
      {id:1,
        name: "Murtaza",
        code: 1234,
        category: "Demo",
        quantity: 1
      }, {
        id: 2,
        name: "Murtaza",
        code: 1234,
        category: "Demo",
        quantity: 1
      },
      { id: 3, code: 'SRC1', name: 'Criteria A', category: 'Cat1', quantity: 10 },
      { id: 4, code: 'SRC2', name: 'Criteria B', category: 'Cat2', quantity: 25 },
      { id: 5, code: 'SRC3', name: 'Criteria C', category: 'Cat3', quantity: 40 }
    ]
  }

  onEditCriteria(criteria: any) {
    console.log('Edit clicked:', criteria);
    // Your edit logic here
  }

  onDeleteCriteria(criteria: any) {
    this.criteria = this.criteria.filter(c => c.id !== criteria.id);
    console.log('Delete clicked:', criteria);
    // Your delete logic here
  }

}
