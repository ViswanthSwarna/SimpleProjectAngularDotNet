import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environments/evironment';

@Injectable({
  providedIn: 'root',
})
export class ResumeService {
  constructor(private http: HttpClient) {}

  uploadNewResume(file: any): Observable<any> {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(
      environment.domainUrl + '/api/Resume/upload',
      formData
    );
  }

  updateResume(file: any,id:number): Observable<any> {
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(
      environment.domainUrl + '/api/Resume/update/'+id,
      formData
    );
  }

  downloadResume(id:number): Observable<any> {
    return this.http.get(
      environment.domainUrl + '/api/Resume/download/'+id,
      { responseType: 'blob'}
    );
  }


}
