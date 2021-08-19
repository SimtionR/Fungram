import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateprofileComponent } from './createprofile/createprofile.component';
import { DetailPostComponent } from './detail-post/detail-post.component';
import { LoginComponent } from './login/login.component';
import { PostListComponent } from './post-list/post-list.component';
import { PostComponent } from './post/post.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './services/auth-guard.service';
import { UpdatePostComponent } from './update-post/update-post.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path:'register', component: RegisterComponent},
  {path:'createProfile', component: CreateprofileComponent, canActivate: [AuthGuardService]},
  {path: 'post', component: PostComponent, canActivate: [AuthGuardService]},
  {path: 'posts', component: PostListComponent, canActivate: [AuthGuardService]},
  {path: 'posts/:id', component: DetailPostComponent, canActivate:[AuthGuardService]},
  {path: 'posts/:id/update',component: UpdatePostComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
