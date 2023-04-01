import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Observable, BehaviorSubject,Subject, map } from 'rxjs';
import { CandidateService } from '../services/candidate.service';
import { ResumeService } from '../services/resume.service';

declare var window:any;

@Component({
  selector: 'app-candidate-list',
  templateUrl: './candidate-list.component.html'
})
export class CandidateListComponent implements OnInit {
  candidateList$:Observable<any> = new Subject<Array<any>>();
  formModal:any;
  id!:number;
  experienceGreaterThanInput$ = new BehaviorSubject<number>(0);

  constructor(private candidateService:CandidateService,private resumeService:ResumeService){
    this.getCandidates();
  }
  ngOnInit(): void {
    this.formModal = new window.bootstrap.Modal(
      document.getElementById('modal-delete')
    );
    this.experienceGreaterThanInput$.subscribe({next:response=>this.getCandidates()})
  }

  filterByExperience(event:any){
    this.experienceGreaterThanInput$.next(event.target.value);
  }

  openDeleteModal(id:any){
    this.formModal.show();
    this.id = id;
  }

  getCandidates(){
    this.candidateList$ = this.candidateService.getAllCandidates().pipe(
      map( results => results.filter((r: any) => r.experience > this.experienceGreaterThanInput$.getValue()) )
    );
  }

  downloadResume(resumeId:any){
    this.resumeService.downloadResume(resumeId).subscribe({next:x=>this.download(x)});
  }

  download(data:any){
    const blob = new Blob([data], { type: 'application/pdf' });
    const url= window.URL.createObjectURL(blob);
    window.open(url);
  }

  delete(){
    this.formModal.hide();
    this.candidateService.deleteCandidate(this.id).subscribe({next:response=>this.getCandidates()})
  }
}
