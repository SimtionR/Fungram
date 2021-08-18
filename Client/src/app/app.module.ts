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

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,  
    CreateprofileComponent,
    PostComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    CommonModule,
    HttpClientModule,
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
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
