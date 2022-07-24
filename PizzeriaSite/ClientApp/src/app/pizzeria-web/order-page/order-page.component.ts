import { Component, OnInit } from '@angular/core';
import { IOrder, IOrderProduct } from '../shared/order.interface';
import { AbstractControl, ControlConfig, FormControl, FormControlDirective, FormGroup, Validators } from '@angular/forms';
import { OrderSerive } from '../shared/order.service';
import { keyframes } from '@angular/animations';
import { ChangeDetectorRef,AfterContentChecked} from '@angular/core'
import { CustomerAccountService } from '../shared/customer-account.service';
import { ICustomerAccount } from '../shared/customer-account.interface';
import { ProductService } from '../shared/product.service';
import { IProduct } from '../shared/product.interface';

@Component({
  selector: 'app-order-page',
  templateUrl: './order-page.component.html',
  styleUrls: ['./order-page.component.css']
})
export class OrderPageComponent implements OnInit {

  public orders!:IOrder[];

  public form!: FormGroup;

  public productControls!:  Map<string,  FormControl>

  public productControlsKeys!: string[]

  public customerAccounts!: ICustomerAccount[]

  public products! : IProduct[]


  constructor(private orderService: OrderSerive, private customerAccountService: CustomerAccountService, private productService: ProductService) {
    this.GetOrders();

    this.getPorducts();
    this.getCustomerAccounts()

   }

  ngOnInit(): void {

    this.productControls = new Map([["product1", new FormControl(null, [Validators.required])]]);

    this.form = new FormGroup({
      customerId: new FormControl(null, [Validators.required]),
      product1: this.productControls.get("product1")!
    })

    this.productControlsKeys = Array.from(this.productControls.keys());
    console.log(this.productControlsKeys)


   
  }

  public GetOrders() {
      this.orderService.GetOrders().subscribe( x => {
          this.orders = Object.assign([], x);
          console.log(this.orders);
      })
  }

  public deleteOrder(order:IOrder) {

    this.orderService.deleteOrder(order.id).subscribe(() => {
      this.GetOrders();
    })
  }

  public addOrder() {
    if (this.form.invalid) {
      return
    }

    
    let order: IOrder = {
      id: 0,
      customerId: this.customerIdCOntrol.value,
      timeOrder: new Date(),
      customerAccountDto: null,
      orderProductsDto: this.getProductOrder()
    };
    console.log(order)


    this.orderService.addOrder(order).subscribe(()=> {
      this.GetOrders()
    });


    

  }
  public newProduct() {

    let nameControl = `product${this.productControls.size + 1}`;
    this.productControls.set(nameControl, new FormControl(null, [Validators.required]));
    this.form.addControl(nameControl, this.productControls.get(nameControl));
    this.productControlsKeys = Array.from(this.productControls.keys());
  }

  get customerIdCOntrol(): AbstractControl {
    return this.form.get("customerId")!;
  }

  getProductOrder(): IOrderProduct[] {
    
    let products: IOrderProduct[] = []
    this.productControls.forEach((value: FormControl, key: string) => {
      products.push({
        orderId : 0,
        productId: this.form.get(key)?.value,
        id: 0,
        product: null
      })
      
    })

    return products;
  }


  getCustomerAccounts() {
    this.customerAccountService.getCustomerAccounts().subscribe((s)=> {
      this.customerAccounts = Object.assign([], s);
    });
  }

  getPorducts() {
    this.productService.getProducts().subscribe((s)=> {
      this.products = Object.assign([], s);
  });
}


}
