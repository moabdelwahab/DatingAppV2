import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-errors',
  templateUrl: './errors.component.html',
  styleUrls: ['./errors.component.css']
})
export class ErrorsComponent implements OnInit {
  
  baseUrl:string = 'https://localhost:5001/api/buggy/';
  validationErrors:string[]=[];

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  
  }

  get404(){
    this.http.get(this.baseUrl+'not-found').subscribe(
      next=>{console.log(next);},errors=>{console.log(errors);});
  }

  
  get400(){
    this.http.get(this.baseUrl+'bad-request').subscribe(
      next=>{console.log(next);},errors=>{console.log(errors);});
  }

  
  get401(){
    this.http.get(this.baseUrl+'auth').subscribe(
      next=>{console.log(next);},errors=>{console.log(errors);});
  }

  get500(){
    this.http.get(this.baseUrl+'server-error').subscribe(
      next=>{console.log(next);},errors=>{console.log(errors);});
  }
  
  get400Validations(){
    this.http.post('https://localhost:5001/api/account/Register',{username:'',password:'123'}).subscribe(
      next=>{console.log(next);},
      errors=>{this.validationErrors=errors;console.log(errors)});

  }

}
