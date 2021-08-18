import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule,FormControl, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { AuthService } from '../services/auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  
  constructor(private fb: FormBuilder, 
    private authService : AuthService){
    this.loginForm = this.fb.group({
      'username': ['' ,[Validators.required]],
      'password': ['', [Validators.required]]

    })
  }

 

  ngOnInit(): void {
  }

  login(){
    this.authService.login(this.loginForm.value).subscribe(
      data =>{ this.authService.saveToekn(data['token']);}
    );
  }


  get username(){
    return this.loginForm.get('username');
  }

  get password(){
    return this.loginForm.get('password');
  }

}
