import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/evironment';
import { candidate } from '../models/candidate.model';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  constructor(private httpClient:HttpClient) { }

  getAllCandidates():Observable<any>
  {
    return this.httpClient.get(environment.domainUrl +  '/api/Candidate');
  }

  getCandidate(id:any):Observable<any>
  {
    return this.httpClient.get(environment.domainUrl +  '/api/Candidate/' + id);
  }

  addCandidate(requestBody:candidate):Observable<any>{
    return this.httpClient.post(environment.domainUrl +  '/api/Candidate',requestBody);
  }

  updateCandidate(requestBody:candidate):Observable<any>{
    return this.httpClient.put(environment.domainUrl +  '/api/Candidate',requestBody);
  }

  deleteCandidate(id:any):Observable<any>{
    return this.httpClient.delete(environment.domainUrl +  '/api/Candidate/' + id);
  }
}
