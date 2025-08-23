import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriteriaFeatureComponent } from './criteria-feature.component';

describe('CriteriaFeatureComponent', () => {
  let component: CriteriaFeatureComponent;
  let fixture: ComponentFixture<CriteriaFeatureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CriteriaFeatureComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CriteriaFeatureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
