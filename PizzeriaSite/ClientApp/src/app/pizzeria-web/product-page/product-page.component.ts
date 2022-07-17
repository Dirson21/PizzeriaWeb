import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { IProduct } from '../shared/product.interface';
import { ProductService } from '../shared/product.service';
import { fromEventPattern } from 'rxjs';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {

  public products: IProduct[] = []

  public form!: FormGroup;
  
  constructor(private productService: ProductService) {
    this.getProducts();
   }

  ngOnInit(): void {
    this.form = new FormGroup({
      id: new FormControl(null, [Validators.required]),
      name: new FormControl(null, [Validators.required]),
      price: new FormControl(null, [Validators.required])
    })
    this.form.controls["id"].setValue(0);
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

  public addProductItem(){
    if (this.form.invalid){
      return
    }

    this.productService.addProduct({
      id: 0,
      name: this.nameControl.value,
      price: this.priceControl.value
    }).subscribe(()=>{
      this.getProducts();
      this.form.markAsUntouched();
    })
  }
  

  public updateProductItem()
  {
    if (this.form.invalid){
      return
    }

    this.productService.updateProduct({
      id: this.idControl.value,
      name: this.nameControl.value,
      price: this.priceControl.value
    }).subscribe(()=>{
      this.getProducts();
      this.form.markAsUntouched();
    })
  }

  get idControl(): AbstractControl {
    return this.form.get("id")!;
  }
  get nameControl(): AbstractControl {
    return this.form.get("name")!;
  }
  get priceControl(): AbstractControl {
    return this.form.get("price")!;
  }

}
