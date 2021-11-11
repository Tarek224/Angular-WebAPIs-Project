import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserLogin, UserRegister } from '../SharedClasses/User';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  _urlRegister:string = "https://localhost:44353/api/account/register";
  
  _urlLogin:string = "https://localhost:44353/api/account/login";

  constructor(private http:HttpClient) { }

  enrolleUser(user:UserRegister):Observable<UserRegister>
  {
    return this.http.post<UserRegister>(this._urlRegister , user);
  }

  checkUser(user:UserLogin):Observable<UserLogin>
  {
    return this.http.post<UserLogin>(this._urlLogin , user);
  }
}
