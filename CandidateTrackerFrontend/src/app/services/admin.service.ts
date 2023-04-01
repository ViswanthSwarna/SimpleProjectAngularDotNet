import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor() { }
  private isAdmin:boolean = true;

  isAdminUser():boolean
  {
    return this.isAdmin;
  }

  SetUserPrivilege(isAdmin:boolean)
  {
    this.isAdmin = isAdmin;
  }
}
