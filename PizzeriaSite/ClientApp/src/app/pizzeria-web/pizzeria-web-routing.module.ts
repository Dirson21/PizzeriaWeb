import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PizzeriaWebPageComponent } from './pizzeria-web-page/pizzeria-web-page.component';
import { RouterModule, Routes } from '@angular/router';
import { ProductPageComponent } from './product-page/product-page.component';

const routes: Routes = [
  {
    path: "pizzeria-web",
    component: PizzeriaWebPageComponent
  },
  {
    path:"product",
    component: ProductPageComponent
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class PizzeriaWebRoutingModule { }
