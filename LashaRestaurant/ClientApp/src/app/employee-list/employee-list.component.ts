import { Component, OnInit } from "@angular/core";
import { ColDef } from "ag-grid-community";
import { EmployeeGet } from "../services/employee.model";
import { EmployeeService } from "../services/employee.service";

@Component({
  selector: "app-employee-list",
  templateUrl: "./employee-list.component.html",
  styleUrls: ["./employee-list.component.css"],
})
export class EmployeeListComponent implements OnInit {
  columnDefs: ColDef[] = [
    { field: "employeeId", headerName: "Id", sortable: true, filter: true },
    {
      field: "employeeFirstName",
      headerName: "First Name",
      sortable: true,
      filter: true,
    },
    {
      field: "employeeLastName",
      headerName: "Last Name",
      sortable: true,
      filter: true,
    },
    { field: "dateOfBirth", headerName: "DOB", sortable: true, filter: true },
    { field: "gender", headerName: "Gender", sortable: true, filter: true },
  ];

  rowData: EmployeeGet[] = [];
  constructor(private employeeService: EmployeeService) {}

  ngOnInit() {
    this.employeeService.getEmployees().subscribe((e) => {
      this.rowData = e;

      this.rowData.forEach((row) => {
        row.dateOfBirth = new Date(row.dateOfBirth);
      });
    });
  }
}
