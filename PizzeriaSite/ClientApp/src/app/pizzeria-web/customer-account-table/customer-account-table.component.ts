import { Component, OnInit } from '@angular/core';
import { ICustomerAccount } from '../shared/customer-account.interface';
import { EventEmitter, Input, Output } from "@angular/core";


@Component({
  selector: 'app-customer-account-table',
  templateUrl: './customer-account-table.component.html',
  styleUrls: ['./customer-account-table.component.css']
})
export class CustomerAccountTableComponent implements OnInit {


  @Input() public dataSource!: ICustomerAccount[];
  @Output() public delete: EventEmitter<ICustomerAccount> = new EventEmitter<ICustomerAccount>();
  constructor() { }


  displayedColumns: string[] = ['id', 'login', 'password', 'balance', 'delete'];

  public deleteClicked(item:ICustomerAccount)
  {
      this.delete.emit(item);
  }


  ngOnInit(): void {
  }

}
