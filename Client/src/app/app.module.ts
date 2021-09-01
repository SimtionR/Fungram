import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './services/auth.service';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { CreateprofileComponent } from './createprofile/createprofile.component';
import { ProfileService } from './services/profile.service';
import { AuthGuardService } from './services/auth-guard.service';
import { TokenInterceptorService } from './services/token-interceptor.service';
import {PostService} from './services/post.service'
import { PostComponent } from './post/post.component';
import { PostListComponent } from './post-list/post-list.component';
import { DetailPostComponent } from './detail-post/detail-post.component';
import { UpdatePostComponent } from './update-post/update-post.component';
import { ProfileComponent } from './profile/profile.component';
import { CommentListComponent } from './comment-list/comment-list.component';
import { CreateCommentComponent } from './create-comment/create-comment.component';
import { CommentDetailComponent } from './comment-detail/comment-detail.component';
import { ReactionsComponent } from './reactions/reactions.component';
import { ErrorInterceptorService } from './services/error-interceptor.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,  
    CreateprofileComponent,
    PostComponent,
    PostListComponent,
    DetailPostComponent,
    UpdatePostComponent,
    ProfileComponent,
    CommentListComponent,
    CreateCommentComponent,
    CommentDetailComponent,
    ReactionsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    CommonModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    AuthService, 
    ProfileService, 
    AuthGuardService,
    PostService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi:true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
