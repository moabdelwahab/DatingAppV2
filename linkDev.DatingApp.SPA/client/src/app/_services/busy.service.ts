import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {

  ServiceBusyCount = 0;
  constructor(private spinnerService : NgxSpinnerService) { }

  Busy(){
    this.ServiceBusyCount++;
    this.spinnerService.show(null,{
      bdColor:"rgba(51,51,51,0.8)",
      size:"medium",
      color:"#fff",
      type:"ball-scale-multiple"
    });
  }

  Idle()
  {
    if(this.ServiceBusyCount <=0)
    {
      this.ServiceBusyCount=0;
      this.spinnerService.hide();
    }
  }

}
