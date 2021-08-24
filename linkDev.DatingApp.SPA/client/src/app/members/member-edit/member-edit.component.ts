import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/members/Member';
import { User } from 'src/app/_models/User';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  user:User;
  member:Member;
  @ViewChild('editForm') editform:NgForm;
  @HostListener('window:onbeforeunload',['$event']) unloadNotification($event:any){
    if(this.editform.dirty)
    {
       $event.retrunValue=true;
    }
  }

  constructor(private accountService:AccountService,private memberService:MembersService ,private toastr:ToastrService) { }

  ngOnInit(): void {
    this.accountService.currentUser$.subscribe(user =>
      {
        this.user=user;
        if(user)
        {
          this.memberService.GetMember(this.user.username).subscribe(
            memberRes=>this.member=memberRes);
        }
      })
    }

    UpdateMember():void
    {
      this.memberService.UpdateMember(this.member).subscribe(()=>
      {
        this.toastr.success("Updated Successfully ...");
        this.editform.reset(this.member);
      });
    }
}
