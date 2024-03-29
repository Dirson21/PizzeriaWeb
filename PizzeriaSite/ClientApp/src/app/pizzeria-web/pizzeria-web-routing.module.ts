import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PizzeriaWebPageComponent } from './pizzeria-web-page/pizzeria-web-page.component';
import { RouterModule, Routes } from '@angular/router';
import { ProductPageComponent } from './product-page/product-page.component';
import { OrderPageComponent } from './order-page/order-page.component';

const routes: Routes = [
  {
    path: "pizzeria-web",
    component: PizzeriaWebPageComponent
  },
  {
    path:"product",
    component: ProductPageComponent
  },
  {
    path:"order",
    component: OrderPageComponent
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class PizzeriaWebRoutingModule { }
