import { Component, OnInit } from '@angular/core';
import { IOrder, IOrderProduct } from '../shared/order.interface';
import { EventEmitter, Input, Output } from "@angular/core";


@Component({
  selector: 'app-order-table',
  templateUrl: './order-table.component.html',
  styleUrls: ['./order-table.component.css']
})
export class OrderTableComponent implements OnInit {

  @Input() public dataSource!: IOrder[];
  @Output() public delete: EventEmitter<IOrder> = new EventEmitter<IOrder>();

  

  public displayedColumns: string[] = ["login","orderDate", "products", "delete"];

  public deleteClicked(item: IOrder) {
      this.delete.emit(item);
  }

  constructor() { }

  ngOnInit(): void {
  }

}
