import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PizzeriaWebPageComponent } from './pizzeria-web/pizzeria-web-page/pizzeria-web-page.component';
const routes: Routes = [
    {
        path: '**',
        component: PizzeriaWebPageComponent
    }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }