import {Injectable} from "@angular/core";
import { ICustomerAccount } from "./customer-account.interface";
import { Observable } from "rxjs";
import { HttpClient, HttpParams, HttpRequest } from "@angular/common/http";


@Injectable()
export class CustomerAccountService {
    private readonly apiUrl: string = "http://localhost:4200/api/CustomerAccount"

    constructor(private httpClient: HttpClient) {
    }

    public addCustomerAccount(customerAccount: ICustomerAccount): Observable<null> {
        return this.httpClient.post<null>(this.apiUrl, customerAccount);
    }

    public getCustomerAccountByLogin(login: string): Observable<ICustomerAccount> {

        return this.httpClient.get<ICustomerAccount>(`${this.apiUrl}/search`,{
            params: new HttpParams().set("login", login)
        } );
    }

    public deleteCustomerAccount(id: number): Observable<object> {
        return this.httpClient.delete(`${this.apiUrl}/${id}`);
    }

    public updateCustomerAccount(customerAccount: ICustomerAccount): Observable<null> {
        return this.httpClient.put<null>(`${this.apiUrl}/${customerAccount.id}`,  customerAccount);
    }

    public getCustomerAccounts(): Observable<ICustomerAccount[]> {

        return this.httpClient.get<ICustomerAccount[]>(this.apiUrl);
    }

    public getCustomerAccount(id:number): Observable<ICustomerAccount>
    {

        return this.httpClient.get<ICustomerAccount>(`${this.apiUrl}/${id}`);
    }

}