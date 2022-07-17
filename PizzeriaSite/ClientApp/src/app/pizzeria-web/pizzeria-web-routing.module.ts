import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PizzeriaWebPageComponent } from './pizzeria-web-page/pizzeria-web-page.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: "pizzeria-web",
    component: PizzeriaWebPageComponent
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class PizzeriaWebRoutingModule { }
