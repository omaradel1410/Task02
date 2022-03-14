import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class APIsService {
  baseUrl = `http://localhost:11713/API/Employee/`

  constructor(public _HttpClient:HttpClient) {}

  
  public GetAllEmployee(paging:number):Observable<any>
  {
    return  this._HttpClient.get(`${this.baseUrl}GetEmployees/${paging}`);
  }
 
  public createEmployee(data: any ):Observable<any>
  {
    return  this._HttpClient.post(`${this.baseUrl}CreateEmployee`, data);
  }
 
  public getEmployeeById(id:number ):Observable<any>
  {
    return  this._HttpClient.get(`${this.baseUrl}GetEmployeeById/${id}`);
  }

  public UpdateEmployee(data:any ):Observable<any>
  {
    return  this._HttpClient.put(`${this.baseUrl}UpdateEmployee`, data);
  }

  public DeleteEmployee(id:number ):Observable<any>
  {

    return  this._HttpClient.delete(`${this.baseUrl}DeleteEmployee/${id}`);
  }

}
