import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { CandidateModel } from './add-candidate.model';

@Component({
  selector: 'app-add-candidate',
  templateUrl: './add-candidate.component.html'
})
export class AddCandidateComponent {
  constructor(private http: HttpClient){
    this.http = http;
  }
  addCandidate:CandidateModel = new CandidateModel();
  candidateList:any = new Array<CandidateModel>();
  Add(){
    this.http.post('http://localhost:5171/Candidate/AddCandidate'
    ,this.addCandidate).subscribe({next:res=>this.Success(res)})
    this.addCandidate = new CandidateModel();
  }
  Success(res:any)
  {
    this.candidateList = res;
  }
}
