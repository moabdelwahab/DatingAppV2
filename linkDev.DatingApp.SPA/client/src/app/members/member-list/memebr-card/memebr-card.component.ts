import { Component, Input, OnInit } from '@angular/core';
import { Member } from 'src/app/_models/members/Member';

@Component({
  selector: 'app-memebr-card',
  templateUrl: './memebr-card.component.html',
  styleUrls: ['./memebr-card.component.css']
})
export class MemebrCardComponent implements OnInit {
@Input() member:Member;

  constructor() { }

  ngOnInit(): void {
  }

}
