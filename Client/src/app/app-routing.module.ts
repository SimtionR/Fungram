import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateprofileComponent } from './createprofile/createprofile.component';
import { LoginComponent } from './login/login.component';
import { PostComponent } from './post/post.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './services/auth-guard.service';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path:'register', component: RegisterComponent},
  {path:'createProfile', component: CreateprofileComponent, canActivate: [AuthGuardService]},
  {path: 'post', component: PostComponent, canActivate: [AuthGuardService]}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
