import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AddCandidateComponent } from './add-candidate/add-candidate.component';
import { CandidateListComponent } from './candidate-list/candidate-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    AddCandidateComponent,
    CandidateListComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      {path: 'add-candidate', component: AddCandidateComponent},
      {path: 'candidate-list', component: CandidateListComponent},
      {path: '', component: AddCandidateComponent},
    ]), HttpClientModule, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
