import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule,FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProfileService } from '../services/profile.service';

@Component({
  selector: 'app-createprofile',
  templateUrl: './createprofile.component.html',
  styleUrls: ['./createprofile.component.css']
})
export class CreateprofileComponent {
  profileForm: FormGroup;
  
  constructor(private fb: FormBuilder, private profileService: ProfileService) {
    this.profileForm = this.fb.group({
      'ProfilePicture': ['', Validators.required],
      'About': ['']
    })
   }



  create()
  {
    this.profileService.create(this.profileForm.value).subscribe( res => 
      {
        console.log(res);
      })
  }

  get ProfilePicture()
  {
    return this.profileForm.get('ProfilePicture');
  }

  

}
