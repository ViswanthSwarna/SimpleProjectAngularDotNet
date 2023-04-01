import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { AdminService } from './services/admin.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'CandidateTracker';

  constructor(private adminService:AdminService) {    
  }

  changeAdminStatus(event:any){
    this.adminService.SetUserPrivilege(!this.adminService.isAdminUser());
  }
}
