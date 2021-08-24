import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Member } from 'src/app/_models/members/Member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css'],
  encapsulation:ViewEncapsulation.Emulated
})
export class MemberListComponent implements OnInit {

  constructor(private memberService:MembersService) { }
  members:Member[];

  ngOnInit(): void {

   this.getMembers();

  }

  getMembers()
  {
      this.memberService.GetAllMembers().subscribe(members=>{
        this.members=members;
        console.log(members);
      });
    
  }


}
