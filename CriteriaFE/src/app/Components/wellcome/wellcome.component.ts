import { Component } from '@angular/core';

@Component({
  selector: 'app-wellcome',
  imports: [],
  templateUrl: './wellcome.component.html',
  styleUrl: './wellcome.component.scss'
})
export class WellcomeComponent {
  showName = false;
  showWollcode = false;

  ngOnInit() {
    // Show "Murtaza Bohra" immediately
    setTimeout(() => {
      this.showName = true;

      // Show "Wollcode" after 2 seconds
      setTimeout(() => {
        this.showWollcode = true;
      }, 2000);
    }, 100);
  }

}
