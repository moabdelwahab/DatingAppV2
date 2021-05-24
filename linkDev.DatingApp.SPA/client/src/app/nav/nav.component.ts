import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from '../_models/User';
import { UserToLogin } from '../_models/UserToLogin';
import { AccountService } from '../_services/account.service';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
 
  constructor(public accService:AccountService, private router:Router) {}
  loginUser:any = {};
  LoggedUser:User;
  currentUser$ : Observable<User>;


  ngOnInit(): void {
  }

  
  login()
  {
    this.accService.login(this.loginUser).subscribe(response => {
    this.router.navigateByUrl("/members");
    },error => {
    console.log(error); 
    });
  }


  Logout()
  {
    this.LoggedUser=null;
    this.accService.LogOut();
    this.router.navigateByUrl("/");

  }


}
