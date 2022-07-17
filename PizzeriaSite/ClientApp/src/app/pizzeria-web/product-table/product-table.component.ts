import { Component, OnInit } from '@angular/core';
import { EventEmitter, Input, Output } from "@angular/core";
import { IProduct } from '../shared/product.interface';





@Component({
  selector: 'app-product-table',
  templateUrl: './product-table.component.html',
  styleUrls: ['./product-table.component.css']
})
export class ProductTableComponent implements OnInit {

  constructor() { }
  @Input() public dataSource!: IProduct[];
  @Output() public delete: EventEmitter<IProduct> = new EventEmitter<IProduct>();


  displayedColumns: string[] = ['id', 'name', 'price', "delete"];

  public deleteClicked(item:IProduct)
  {
      this.delete.emit(item);
  }




  ngOnInit(): void {
  }

}
