import { Component, OnInit } from '@angular/core';
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
 
  constructor(public accService:AccountService) {}
  loginUser:any = {};
  LoggedUser:User;
  currentUser$ : Observable<User>;


  ngOnInit(): void {
        
  }

  
  login()
  {
    this.accService.login(this.loginUser).subscribe(response => {
    },error => {
    console.log(error);      
    });
  }


  Logout()
  {
    this.LoggedUser=null;
    this.accService.LogOut();
  }


}
