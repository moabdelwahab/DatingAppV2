import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { User } from './_models/User';
import { AccountService } from './_services/account.service';
import {google} from '@google/maps'


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit , AfterViewInit  {
  title = 'Dating App Hello From Eg';
  users:any;


  constructor(private http:HttpClient
              ,private accountService:AccountService
              ) { 
    
  }
  ngAfterViewInit(): void {
       // Initialize and add the map
       function initMap(): void {
        // The location of Uluru
         const uluru = { lat: -25.344, lng: 131.036 };
        // The map, centered at Uluru
         const map = new google.maps.Map(
         document.getElementById("map") as HTMLElement,
         {
           zoom: 4,
           center: uluru,
         }
        );
     
        // The marker, positioned at Uluru
         const marker = new google.maps.Marker({
         position: uluru,
         map: map,
        });
     }
  }
  ngOnInit() {
    this.SetCurrentUser();
  }


 

  SetCurrentUser()
  {
      const user: User = JSON.parse(localStorage.getItem("user")) ;
      this.accountService.SetCurrentUser(user);
  }

}
