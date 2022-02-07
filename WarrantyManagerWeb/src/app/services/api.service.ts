import {
    HttpClient,
    HttpErrorResponse,
    HttpHeaders
  } from '@angular/common/http';
  
  import { catchError, retry } from 'rxjs/operators';
  import { Observable, throwError } from 'rxjs';
  import { environment } from 'src/environments/environment';
  import { Injectable } from '@angular/core';
  
  @Injectable({
    providedIn: 'root'
  })
  export class ApiService<T> {
    apiUrl = environment.apiUrl;
  
    constructor(private httpClient: HttpClient) {}
  
    httpOptions = {
      headers: new HttpHeaders().set('Content-Type', 'application/json')
    };
  

    public post(item: T, resource: string): Observable<T> {
      return this.httpClient
        .post<T>(`${this.apiUrl}/${resource}`, item, this.httpOptions)
        .pipe(retry(2), catchError(this.handleError));
    }
  
    public put(item: T, resource: string, id?: string): Observable<T> {
      return this.httpClient
        .put<T>(`${this.apiUrl}/${resource}/${id}`, item, this.httpOptions)
        .pipe(retry(2), catchError(this.handleError));
    }
  
    public getById(id: string, resource: string): Observable<T> {
      return this.httpClient
        .get<T>(`${this.apiUrl}/${resource}/${id}`)
        .pipe(retry(2), catchError(this.handleError));
    }
  
    public get(resource: string, query: string): Observable<T[]> {

      let restUrl = `${this.apiUrl}/${resource}`;
      if (query !== '') {
        restUrl = `${this.apiUrl}/${resource}?${query}`;
      }
      return this.httpClient
        .get<T[]>(restUrl)
        .pipe(retry(2), catchError(this.handleError));
    }
  
    public delete(resource: string, id?: string): Observable<any> {
      return this.httpClient
        .delete(`${this.apiUrl}/${resource}/${id}`)
        .pipe(retry(2), catchError(this.handleError));
    }
  
    private handleError(error: HttpErrorResponse) {
      let errorMessage = '';
      if (error.error instanceof ErrorEvent) {
        errorMessage = error.error.message;
      } else {
        errorMessage = `Status: ${error.status}, ` + `Message: ${error.message}`;
      }
      console.log(error);
      return throwError(errorMessage);
    }
  }
