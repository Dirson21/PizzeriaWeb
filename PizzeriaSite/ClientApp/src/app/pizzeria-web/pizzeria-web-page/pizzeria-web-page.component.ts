import { Component, OnInit } from '@angular/core';
import { ICustomerAccount } from '../shared/customer-account.interface';
import { CustomerAccountService } from '../shared/customer-account.service';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { IProduct } from '../shared/product.interface';
import { ProductService } from '../shared/product.service';

@Component({
  selector: 'app-pizzeria-web-page',
  templateUrl: './pizzeria-web-page.component.html',
  styleUrls: ['./pizzeria-web-page.component.css']
})
export class PizzeriaWebPageComponent implements OnInit {

  public customerAccounts: ICustomerAccount[] = [];
  public products: IProduct[] = []
  public form!: FormGroup;

  constructor(private customerAccountService: CustomerAccountService, private productService: ProductService) {
    this.getCustomersAccounts() 
    this.getProducts();

   }

  ngOnInit(): void {
    this.form = new FormGroup({
      login: new FormControl(null, [Validators.required]),
      password: new FormControl(null, [Validators.required]),
      balance: new FormControl(null, [Validators.required])
  });

  }

  public getCustomersAccounts(): void {
    this.customerAccountService.getCustomerAccounts().subscribe(s=>
      {this.customerAccounts = Object.assign([], s)});
  }

  public deleteCustomerAccount(customerAccount: ICustomerAccount): void {
      this.customerAccountService.deleteCustomerAccount(customerAccount.id).subscribe(() => {
        this.getCustomersAccounts();
      })
  }

  
  public addCustomerAccountItem(): void {
    if (this.form.invalid)
    {
      return;
    } 

    this.customerAccountService.addCustomerAccount({
      id: 0,
      login: this.loginControl.value,
      password: this.passwordControl.value,
      balance: this.balanceControl.value
    }).subscribe(()=> {
      this.getCustomersAccounts();
      this.form.markAsUntouched()
    })
   
  }

  public getProducts(): void {
    this.productService.getProducts().subscribe(s=> 
      {this.products = Object.assign([], s)});
  }

  public deleteProduct(product:IProduct): void {
    this.productService.deleteProduct(product.id).subscribe(() => {
      this.getProducts();
    })
  }



  get loginControl(): AbstractControl {

    return this.form.get("login")!;
  }
  get passwordControl(): AbstractControl {

    return this.form.get("password")!;
  }
  get balanceControl(): AbstractControl{

    return this.form.get("balance")!;
  }

}
