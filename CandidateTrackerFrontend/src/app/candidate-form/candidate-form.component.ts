import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { candidate } from '../models/candidate.model';
import { CandidateService } from '../services/candidate.service';
import { ResumeService } from '../services/resume.service';

@Component({
  selector: 'app-candidate-form',
  templateUrl: './candidate-form.component.html',
})
export class CandidateFormComponent implements OnInit {
  updateId:number | undefined;
  uploadedText:string   = "";

  candidateForm: FormGroup = this.formBuilder.group({
    name: this.formBuilder.control('',[Validators.required]),
    experience:this.formBuilder.control('',[Validators.required]),
    address: this.formBuilder.control('',[Validators.required]),
    resumeId:this.formBuilder.control('',[Validators.required]),
    phoneNumber: this.formBuilder.control('',[Validators.required]),
    email: this.formBuilder.control('',[Validators.required])
  });

  constructor(
    private formBuilder: FormBuilder,
    private candidateService:CandidateService,
    private router:Router,
    private currentRoute: ActivatedRoute,
    private resumeService:ResumeService) {}

  ngOnInit(): void {
    this.updateId = this.currentRoute.snapshot.params['id'];
    if(this.updateId){
      this.candidateService.getCandidate(this.updateId).subscribe({next:response=>this.onGetCandidateSuccess(response)})
    }
  }
  onGetCandidateSuccess(response: any): void {
    this.candidateForm.setValue({
      name:response.name,
      experience:response.experience,
      address: response.address,
      resumeId:response.resumeId,
      phoneNumber: response.phoneNumber,
      email: response.email
    })
  }

  onSubmit(form: FormGroup<any>) {
    if(this.updateId){
      let requestBody = <candidate>form.value;
      requestBody.candidateId = this.updateId;
      this.candidateService.updateCandidate(<candidate>form.value).subscribe({next:response=>this.onSuccess(response)});
    }else{
      this.candidateService.addCandidate(<candidate>form.value).subscribe({next:response=>this.onSuccess(response)});
    }
  }

  upload(event:any){
    if(this.updateId)
    {
      this.resumeService.updateResume(event.target.files[0],this.candidateForm.value.resumeId).subscribe({next:x=>this.onSuccessResumeUpload(x)});
    }else
    {
      this.resumeService.uploadNewResume(event.target.files[0]).subscribe({next:x=>this.onSuccessResumeUpload(x)});
    }
  }

  onSuccessResumeUpload(res:any)
  {
    this.candidateForm.controls['resumeId'].setValue(res.resumeId);
    this.uploadedText ="success"
  }

  onSuccess(response: any): void {
    this.router.navigate(['']);
  }
}
