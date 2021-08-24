import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorsComponent } from './errors/errors.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { HomeComponent } from './home/home.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';

const routes: Routes = [
  {path:'', component:HomeComponent},
  
  {path:'',runGuardsAndResolvers:'always', canActivate:[AuthGuard],
  children:[
    {path:'members',component:MemberListComponent },
    {path:'members/:username',component:MemberDetailComponent},
    {path:'member/edit',component:MemberEditComponent, canActivate:[AuthGuard], 
    canDeactivate:[PreventUnsavedChangesGuard]},
    {path:'messages',component:MessagesComponent}
  ]},
  {path:'server-error',component:ServerErrorComponent},
  {path:'errors',component:ErrorsComponent},
  {path:'**',component:HomeComponent}

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
