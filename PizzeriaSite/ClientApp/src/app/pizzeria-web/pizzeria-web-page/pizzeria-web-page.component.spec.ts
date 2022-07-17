import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PizzeriaWebPageComponent } from './pizzeria-web-page.component';

describe('PizzeriaWebPageComponent', () => {
  let component: PizzeriaWebPageComponent;
  let fixture: ComponentFixture<PizzeriaWebPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PizzeriaWebPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PizzeriaWebPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
