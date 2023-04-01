import { Routes } from "@angular/router";
import { CandidateFormComponent } from "./candidate-form/candidate-form.component";
import { CandidateListComponent } from "./candidate-list/candidate-list.component";
import { PageNotFoundComponent } from "./page-not-found/page-not-found.component";
import { AuthGuardService } from "./services/auth-guard.service";

export const routes:Routes = [
    {path: '', component: CandidateListComponent},
    {path: 'candidate/:id', component: CandidateFormComponent},
    {path: 'candidate', component: CandidateFormComponent, canActivate:[AuthGuardService]},
    {path: 'candidate-list', component: CandidateListComponent},
    {path: 'page-not-found', component: PageNotFoundComponent},
    {path: '**', component: PageNotFoundComponent},
  ];