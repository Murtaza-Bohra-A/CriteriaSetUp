import { Component, OnInit } from '@angular/core';
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
import { DialogModule } from 'primeng/dialog';
import { HttpServiceService } from '../../services/http-service.service';
@Component({
  selector: 'app-criteria',
  imports: [FormsModule, InputGroupModule, InputGroupAddonModule, InputTextModule, FloatLabelModule, ButtonModule, TableModule, CommonModule,
    DropdownModule,DialogModule],
  templateUrl: './criteria.component.html',
  styleUrl: './criteria.component.scss'
})
export class CriteriaComponent implements OnInit {
  SelectedSource: any;   // bound value
  sources = [];
  Criteria = [];
  displayEditDialog: boolean = false;  // controls dialog visibility
  selectedCriteria: any = {};           // store selected row
  
  srNo: number = 0;
  criteriaTable: any = {};
  constructor(private apiService: HttpServiceService) { }

  ngOnInit() {
    this.apiService.Post("MurtazaAPI/GetCriteriaModule", null).subscribe({
      next: (res) => {
        this.sources = res.data.map((s: any) => s.source)
        this.Criteria = res.data.map((s: any) => s.criteria)
        console.log(this.Criteria);
      },
      error: (err) => {
        console.error('Error fetching data', err);
      }
    })
  }
  ClearInput() {
    this.selectedCriteria = ""
    this.SelectedSource = ""
  }
  loadCriteriatable() {
   
    var obj = {
      ID: null,
      Source: this.SelectedSource ?? null,
      isActive: null,
      StatusName: null,
      Criteria: this.selectedCriteria ?? null,
      FeatureName: null,
      CreatedBy: null,
      CreatedDate: null
    };
    this.apiService.Post("MurtazaAPI/GetCriteriaStatuses", obj).subscribe({
      next: (res) => {
        this.criteriaTable = res.data
        console.log("Criteria Table Data", this.criteriaTable);
        this.ClearInput();
      },
      error: (err) => {
        console.error('Error fetching data', err);
        this.ClearInput();
      }
    })
    
    this.criteriaTable = [
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
    this.selectedCriteria = { ...criteria }; // Clone the selected criteria
    this.displayEditDialog = true; // Show the dialog
  }
  saveEdit() {
    //const index = this.criteriaTable.findIndex(c => c.id === this.selectedCriteria.id);
    //if (index !== -1) {
    //  this.criteriaTable[index] = { ...this.selectedCriteria };
    //}
    this.displayEditDialog = false;
  }

  onDeleteCriteria(criteria: any) {
  //  this.criteriaTable = this.criteriaTable.filter(c => c.id !== criteria.id);
    console.log('Delete clicked:', criteria);
    // Your delete logic here
  }

}
