import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { EmployeeGet } from "./employee.model";

@Injectable({
  providedIn: "root",
})
export class EmployeeService {
  private apiPath = "/api/Employee";

  constructor(private http: HttpClient) {}

  getEmployees(): Observable<EmployeeGet[]> {
    return this.http.get<EmployeeGet[]>(`${this.apiPath}`);
  }
}
