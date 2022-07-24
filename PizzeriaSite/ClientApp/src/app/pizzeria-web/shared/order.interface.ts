import { ICustomerAccount } from "./customer-account.interface";
import { IProduct } from "./product.interface";

export interface IOrder{
    id: number,
    customerId: number,
    timeOrder: Date,
    customerAccountDto: ICustomerAccount|null,
    orderProductsDto: IOrderProduct[]
    
    
}

export interface IOrderProduct {
    id: number,
    orderId: number,
    productId: number,
    product: IProduct|null
}