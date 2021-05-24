import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Input() usersFromHomeComponent:any ;
  @Output() CancelRegister : EventEmitter<any> = new EventEmitter();
  model:any={};

  constructor(private accountService:AccountService) { }

  ngOnInit(): void {
  }

  Register(){
    this.accountService.Register(this.model).subscribe(user=>{
      this.Cancel();
    });
  }

  Cancel(){
    this.CancelRegister.emit(false); 
  }

}
