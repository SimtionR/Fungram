import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule,FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent  {
  postForm: FormGroup

  constructor(private fb: FormBuilder, private postService: PostService) {
    this.postForm = this.fb.group({
      'ImageUrl': [''],
      'Description':['', Validators.required]
    })
   }


   create()
   {
     this.postService.create(this.postForm.value).subscribe(
       res=> { console.log(res);}
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

  

}
