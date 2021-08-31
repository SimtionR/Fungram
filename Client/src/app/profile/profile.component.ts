import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Profile } from '../models/profile';
import { PostService } from '../services/post.service';
import { ProfileService } from '../services/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  profile!: Profile;

  constructor(private profileService: ProfileService, private router: Router){

  }
 

  ngOnInit(): void {
    this.profileService.get().subscribe(result => 
      {
        this.profile=result;
      });
  }

  viewPosts(){
    this.router.navigate(["posts"]);
    

  }

}
