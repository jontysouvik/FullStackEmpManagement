import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../employee';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
@Component({
  selector: 'app-emp-list',
  templateUrl: './emp-list.component.html',
  styleUrls: ['./emp-list.component.css']
})
export class EmpListComponent implements OnInit {

  employees: Employee[] = [];
  constructor(private http: HttpClient, public router: Router) { }

  ngOnInit() {
    this.refreshEmployees();
  }
  addEmployee() {
    this.router.navigate(['details', '0']);
  }
  editEmployee(id: number) {
    this.router.navigate(['details', id]);
  }
  deleteEmployee(id: number) {
    this.http.delete(environment.apiUrl + '/api/employees/' + id).subscribe(() => {
      this.refreshEmployees();
    });
  }
  refreshEmployees() {
    this.http.get(environment.apiUrl + '/api/employees').subscribe((data: Employee[]) => {
      this.employees = data;
    });
  }
}
