import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpHeaders } from '@angular/common/http';




@Injectable()
export class HttpService {

    constructor(private http: HttpClient) {
    }

    public getRequest<T>(url: string): Observable<T> {
        const headers = new HttpHeaders();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'application/json');
        headers.append('Access-Control-Allow-Methods', 'POST, GET, OPTIONS, DELETE, PUT');
        headers.append('Access-Control-Allow-Origin', '*');
        headers.append('Access-Control-Allow-Headers', "X-Requested-With");
        return this.http.get<T>(url, { headers: headers });
    }

    public postRequest<T>(url: string, data: any): Observable<T> {
        const jsonData = JSON.stringify(data);
        return this.http.post<T>(url, jsonData);
    }

    public putRequest<T>(url: string, data: any): Observable<T> {
        const jsonData = JSON.stringify(data);
        return this.http.put<T>(url, jsonData);
    }

    public delete<T>(url: string): Observable<T> {
        return this.http.delete<T>(url);
    }
}