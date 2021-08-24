import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Loader } from '@googlemaps/js-api-loader';
import { map } from 'rxjs/operators';
import { User } from './_models/User';
import { AccountService } from './_services/account.service';
import {NgxSpinner} from 'ngx-spinner'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit , AfterViewInit  {
  title = 'Dating App Hello From Eg';
  users:any;
  currentMap:any;


  constructor(private http:HttpClient
              ,private accountService:AccountService
              ) { 
    
  }
  ngAfterViewInit(): void {

  }
  ngOnInit() {
    if(this.accountService.currentUser$)
    this.SetCurrentUser();

    // const loader = new Loader({
    //   apiKey: "AIzaSyD91Jk-x0iBw1qN3VhT0tFJeAJSTdIQe1s",
    //   version: "weekly"
    // });

    // loader.load().then(()=>{
    //   this.currentMap = new google.maps.Map(document.getElementById('datingMap'),{
    //     center:{lat:26.8206,lng:30.8025}
    //     ,zoom:8,
    //   })
    // })
  }
  addNewGoogleMapMarker()
  {
    var markerPosition= google.maps.VehicleType.CABLE_CAR
  }
  
 AddMarkers(){

  const map = new google.maps.Map(
    document.getElementById("datingMap") as HTMLElement,
    {
      zoom: 3,
      center: { lat: -28.024, lng: 140.887 },
    }
  );

  // Create an array of alphabetical characters used to label the markers.
  const labels = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

  // Add some markers to the map.
  // Note: The code uses the JavaScript Array.prototype.map() method to
  // create an array of markers based on a given "locations" array.
  // The map() method here has nothing to do with the Google Maps API.


  // Add a marker clusterer to manage the markers.
  // @ts-ignore MarkerClusterer defined via script
  new MarkerClusterer(map, markers, {
    imagePath:
      "https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m",
  });
  const locations = [
    { lat: -31.56391, lng: 147.154312 },
    { lat: -33.718234, lng: 150.363181 },
    { lat: -33.727111, lng: 150.371124 },
    { lat: -33.848588, lng: 151.209834 },
    { lat: -33.851702, lng: 151.216968 },
    { lat: -34.671264, lng: 150.863657 },
    { lat: -35.304724, lng: 148.662905 },
    { lat: -36.817685, lng: 175.699196 },
    { lat: -36.828611, lng: 175.790222 },
    { lat: -37.75, lng: 145.116667 },
    { lat: -37.759859, lng: 145.128708 },
    { lat: -37.765015, lng: 145.133858 },
    { lat: -37.770104, lng: 145.143299 },
    { lat: -37.7737, lng: 145.145187 },
    { lat: -37.774785, lng: 145.137978 },
    { lat: -37.819616, lng: 144.968119 },
    { lat: -38.330766, lng: 144.695692 },
    { lat: -39.927193, lng: 175.053218 },
    { lat: -41.330162, lng: 174.865694 },
    { lat: -42.734358, lng: 147.439506 },
    { lat: -42.734358, lng: 147.501315 },
    { lat: -42.735258, lng: 147.438 },
    { lat: -43.999792, lng: 170.463352 }
  ];
  const markers = locations.map((location, i) => {
    return new google.maps.Marker({
      position: location,
      label: labels[i % labels.length],
    });
  });
 }

 SetCurrentUser()
  {
      const user: User = JSON.parse(localStorage.getItem("user")) ;
      this.accountService.SetCurrentUser(user);
  }

}
