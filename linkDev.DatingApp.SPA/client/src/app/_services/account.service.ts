import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import {map} from 'rxjs/operators';
import { User } from '../_models/User';


 
@Injectable({
  providedIn: 'root'
})

export class AccountService {
  baseUrl:string  = 'https://localhost:5001/api/';
  private currentUserResponse = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserResponse.asObservable(); 


  constructor(private httpclient:HttpClient) { }

  login(model:any)
  {
    return this.httpclient.post(this.baseUrl+'account/login',model).pipe(
      map((response: User) =>
      {
        if(response)
        {
          this.SetCurrentUser(response);
        }
      }
      )
    );
  }


  SetCurrentUser(user:User)
  {
    localStorage.setItem("user",JSON.stringify(user));
    this.currentUserResponse.next(user);
  }

  GetCurrentUser()
  {
  }

  Register(model:any)
  {
    return this.httpclient.post(this.baseUrl+'account/register',model).pipe(
      map((user:User)  =>{
        if(user){
          this.SetCurrentUser(user);
        }
      })
    );
  }

  LogOut()
  {
    localStorage.removeItem("user");
    this.currentUserResponse.next(null);
  }
}
