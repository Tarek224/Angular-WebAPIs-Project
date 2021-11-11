import { Component, OnInit } from '@angular/core';
import { UserServiceService } from '../Services/user-service.service';
import { UserLogin, UserRegister } from '../SharedClasses/User';

@Component({
  selector: 'app-user-registeration',
  templateUrl: './user-registeration.component.html',
  styleUrls: ['./user-registeration.component.scss']
})
export class UserRegisterationComponent implements OnInit {

  userLogin:UserLogin = new UserLogin();
  userRegister:UserRegister = new UserRegister();
  
  constructor(private user:UserServiceService) { }

  ngOnInit(): void {
  }

  onLogin()
  {
    this.user.checkUser(this.userLogin).subscribe(
      data =>
      {
        console.log(data);
      })
  }
  onRegister()
  {
    this.user.enrolleUser(this.userRegister).subscribe(
      data =>
      {
        console.log(data);
      })
  }
}
