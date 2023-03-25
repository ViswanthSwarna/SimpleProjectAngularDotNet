import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { CandidateModel } from '../add-candidate/add-candidate.model';

@Component({
  selector: 'app-candidate-list',
  templateUrl: './candidate-list.component.html'
})
export class CandidateListComponent {
  constructor(private http:HttpClient){
    http.get('http://localhost:5171/Candidate/CandidateList').subscribe({next:res=>this.Success(res)})
  }
  candidateList:any = new Array<CandidateModel>();
  Success(res: Object){
    this.candidateList = res;
  }
}
