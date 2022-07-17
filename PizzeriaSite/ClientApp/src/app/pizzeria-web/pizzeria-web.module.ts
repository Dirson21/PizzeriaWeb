import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PizzeriaWebPageComponent } from './pizzeria-web-page/pizzeria-web-page.component';
import { PizzeriaWebRoutingModule } from './pizzeria-web-routing.module';
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatListModule } from "@angular/material/list";
import { MatIconModule } from "@angular/material/icon";
import { CustomerAccountService } from './shared/customer-account.service';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatSliderModule } from '@angular/material/slider';
import {MatPaginatorModule} from "@angular/material/paginator";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner"
import {MatSortModule} from "@angular/material/sort";
import {MatTableModule } from "@angular/material/table";
import { CustomerAccountTableComponent } from './customer-account-table/customer-account-table.component'
import { ProductService } from './shared/product.service';
import { ProductTableComponent } from './product-table/product-table.component';


@NgModule({
  declarations: [
    PizzeriaWebPageComponent,
    CustomerAccountTableComponent,
    ProductTableComponent
  ],
  imports: [
    CommonModule,
    PizzeriaWebRoutingModule,
    MatCardModule,
    MatButtonModule,
    MatListModule,
    MatIconModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSliderModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatSortModule,
    MatTableModule
  ],
  providers: [
    CustomerAccountService,
    ProductService
  ]
})
export class PizzeriaWebModule { }
