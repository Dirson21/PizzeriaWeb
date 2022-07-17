import {Injectable} from "@angular/core";
import { IProduct } from "./product.interface";
import { Observable } from "rxjs";
import { HttpClient, HttpParams, HttpRequest } from "@angular/common/http";


@Injectable()
export class ProductService {
    private readonly apiUrl: string = "http://localhost:4200/api/Product"

    constructor(private httpClient: HttpClient) {
    }

    public addProduct(product: IProduct): Observable<null> {
        return this.httpClient.post<null>(this.apiUrl, product);
    }

    public getProductByName(name: string): Observable<IProduct> {

        return this.httpClient.get<IProduct>(`${this.apiUrl}/search`,{
            params: new HttpParams().set("name", name)
        } );
    }

    public deleteProduct(id: number): Observable<object> {
        return this.httpClient.delete(`${this.apiUrl}/${id}`);
    }

    public updateProduct(product: IProduct): Observable<null> {
        return this.httpClient.put<null>(`${this.apiUrl}/${product.id}`,  product);
    }

    public getProducts(): Observable<IProduct[]> {

        return this.httpClient.get<IProduct[]>(this.apiUrl);
    }

    public getCustomerProduct(id:number): Observable<IProduct>
    {
        return this.httpClient.get<IProduct>(`${this.apiUrl}/${id}`);
    }

}