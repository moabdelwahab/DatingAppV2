import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Member } from 'src/app/_models/members/Member';
import { MembersService } from 'src/app/_services/members.service';
import {NgxGalleryImage, NgxGalleryOptions} from '@kolkov/ngx-gallery';
import {NgxGalleryAnimation} from '@kolkov/ngx-gallery';



@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit  {
  member:Member;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private memberService:MembersService,private activatRoute:ActivatedRoute) { }

  ngOnInit(): void {
  var username=this.activatRoute.snapshot.paramMap.get('username');
  this.getMember(username);
  this.galleryOptions = [
    {
      width: '500px',
      height: '500px',
      thumbnailsColumns: 4,
      imagePercent:100,
      imageAnimation: NgxGalleryAnimation.Slide,
      preview:false
    }
  ];
  }

  getMember(username:string)
  {
    this.memberService.GetMember(username).subscribe(member=>
      {
       this.member=member;    
       this.galleryImages = this.getImages();
      });
  }

  getImages():NgxGalleryImage[]
  {
    const imageUrls =[];
     for(const photo of this.member.photos)
     {
        imageUrls.push({
          small:photo?.url,
          medium:photo?.url,
          big:photo?.url
       });
     }
     return imageUrls;
  }
}
