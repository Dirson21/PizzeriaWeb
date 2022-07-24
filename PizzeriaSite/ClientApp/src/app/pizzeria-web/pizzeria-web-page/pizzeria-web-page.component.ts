import { Component, OnInit } from '@angular/core';
import { ICustomerAccount } from '../shared/customer-account.interface';
import { CustomerAccountService } from '../shared/customer-account.service';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { ProductService } from '../shared/product.service';
import { MatSelectChange } from '@angular/material/select';

@Component({
  selector: 'app-pizzeria-web-page',
  templateUrl: './pizzeria-web-page.component.html',
  styleUrls: ['./pizzeria-web-page.component.css']
})
export class PizzeriaWebPageComponent implements OnInit {

  public customerAccounts: ICustomerAccount[] = [];
  public form!: FormGroup;

  constructor(private customerAccountService: CustomerAccountService, private productService: ProductService) {
    this.getCustomersAccounts() 


   }

  ngOnInit(): void {
    this.form = new FormGroup({
      login: new FormControl(null, [Validators.required]),
      password: new FormControl(null, [Validators.required]),
      balance: new FormControl(null, [Validators.required]),
      id: new FormControl(null, [Validators.required])
  });
    this.form.controls["id"].setValue(0);

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


  public updateCustomerAccountItem(): void {
    if (this.form.invalid) {
      return;
    }

    this.customerAccountService.updateCustomerAccount({
      id: this.idControl.value,
      login: this.loginControl.value,
      password: this.passwordControl.value,
      balance: this.balanceControl.value
    }).subscribe(()=> {
      this.getCustomersAccounts();
      this.form.markAsUntouched()
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
  get idControl(): AbstractControl {
    return this.form.get("id")!;
  }

  public setLogin(login: MatSelectChange):void
  {
    console.log(login.value)
    let item = this.customerAccounts.find(x => x.id == login.value)
    console.log(item);
    if (item != undefined)  {
      this.loginControl.setValue(item.login);
      return
    }
    this.loginControl.setValue("");
    
    
  }
}
