import { IOrder, IOrderProduct } from "./order.interface";
import { Observable } from "rxjs";
import { HttpClient, HttpParams, HttpRequest } from "@angular/common/http";
import { Injectable} from "@angular/core";

@Injectable()
export class OrderSerive {
    private readonly apiUrl: string = "http://localhost:4200/api/order"

    constructor (private httpClient: HttpClient) {

    }

    public addOrder(order:IOrder): Observable<null> {
        return this.httpClient.post<null>(this.apiUrl, order);
    }

    public deleteOrder(id: number): Observable<object> {
        return this.httpClient.delete(`${this.apiUrl}/${id}`);
    }
 

    public GetOrders(): Observable<IOrder[]> {
        return this.httpClient.get<IOrder[]>(this.apiUrl);
    }



}

