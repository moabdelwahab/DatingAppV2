import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/members/Member';

@Injectable({
  providedIn: 'root'
})
export class MembersService {

  apiUrl = environment.ApiUrl;
  constructor(private http : HttpClient) 
  {
  }
  GetAllMembers():Observable<Member[]>
  {
    return this.http.get<Member[]>( this.apiUrl+'Users/');
  }
  GetMember(username:string):Observable<Member>
  {
    return this.http.get<Member>(this.apiUrl+'Users/'+ username);
  }
  UpdateMember(member:Member)
  {
    return this.http.put(this.apiUrl+'Users',member);
  }

   
}
