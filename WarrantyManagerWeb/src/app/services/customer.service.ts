import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Customer } from '../models/customer';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  constructor(private apiService: ApiService<Customer>) { }


  getAllCustomers(): Observable<Customer[]> {
    return this.apiService.get('customers', '').pipe(
      map(response => {
        return response;
      }),
      catchError(error => {
        return throwError(error);
      }),
    );
  }

  createCustomers(customer: Customer): Observable<Customer> {
    return this.apiService.post(customer,'customers').pipe(
      map(response => {
        return response;
      }),
      catchError(error => {
        return throwError(error);
      }),
    );
  }

  updateCustomer(customer: Customer): Observable<Customer> {
    return this.apiService.put(customer,'customers', customer?.id).pipe(
      map(response => {
        return response;
      }),
      catchError(error => {
        return throwError(error);
      }),
    );
  }



}
