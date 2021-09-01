import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule,FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PostService } from '../services/post.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent  {
  postForm: FormGroup

  constructor(private fb: FormBuilder,
              private postService: PostService,
              private router: Router,
              private toastrService: ToastrService ) {
    this.postForm = this.fb.group({
      'ImageUrl': [''],
      'Description':['', Validators.required]
    })
   }


   create()
   {
     this.postService.create(this.postForm.value).subscribe(
       res=> { this.redirect();
        this.toastrService.success("Post created!")
      }
     )
     

   }

   get ImageUrl()
   {
     return this.postForm.get('ImageUrl');
   }

   get Description()
   {
     return this.postForm.get('Description');
   }

   redirect()
  {
    this.router.navigate(["posts"])
  }
    

   

  

}
