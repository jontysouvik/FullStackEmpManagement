import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../employee';
import { environment } from '../../environments/environment';
// import * as scentences from '../../assets/sentences';
@Component({
  selector: 'app-emp-details',
  templateUrl: './emp-details.component.html',
  styleUrls: ['./emp-details.component.css']
})
export class EmpDetailsComponent implements OnInit {
  name: string;
  sex: string;
  comments: string;
  id: number;
  sexs = ['Male', 'Female'];
  sentences: any;
  names: any;
  constructor(private http: HttpClient, public router: Router, private acR: ActivatedRoute) { }

  ngOnInit() {
    this.acR.params.subscribe((params) => {
      if (params.id) {
        this.id = params.id;
        console.log(this.id);
        if (parseInt(this.id.toString(), 10) !== 0) {
          this.http.get(environment.apiUrl + '/api/employees/' + this.id).subscribe((data: Employee) => {
            this.name = data.name;
            this.sex = data.sex;
            this.comments = data.comments;
          });
        }
      }
    });
    this.http.get('assets/sentences.json').subscribe((data: any) => {
      this.sentences = data.sentences;
    });
    this.http.get('assets/names.json').subscribe((data) => {
      this.names = data;
      console.log(data);
    });
  }
  saveEmployee() {
    console.log(this.name);
    console.log(this.sex);
    console.log(this.comments);
    const emp: Employee = new Employee();
    emp.name = this.name;
    emp.sex = this.sex;
    emp.comments = this.comments;
    console.log(emp);
    if (parseInt(this.id.toString(), 10) === 0) {
      this.http.post(environment.apiUrl + '/api/employees', emp).subscribe((data: any) => {
        this.goToList();
      });
    } else {
      this.http.put(environment.apiUrl + '/api/employees/' + this.id, emp).subscribe((data: any) => {
        this.goToList();
      });
    }

  }
  goToList() {
    this.router.navigate(['list']);
  }
  getRandomNumber(limit: number) {
    return Math.floor(Math.random() * limit);
  }
  fillRandomData() {
    this.comments = this.sentences[this.getRandomNumber(this.sentences.length - 1)].sentence;
    this.sex = this.sexs[this.getRandomNumber(this.sexs.length)];
    const names = this.names[this.sex.toLowerCase()];
    this.name = names[this.getRandomNumber(names.length)].name + ' '
     + this.names.surname[this.getRandomNumber(this.names.surname.length)].name;
    console.log(names);
  }
}
